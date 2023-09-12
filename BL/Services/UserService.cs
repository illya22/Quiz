﻿using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using Core.Entities;
using DL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(AppDbContext context,IMapper mapper,UserManager<ApplicationUser> userManager,IConfiguration configuration,IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _httpContext = httpContext;
        }
        private async Task<ApplicationUser> GetOriginalCurrentUser()
        {
            _httpContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var auth);
            if (StringValues.IsNullOrEmpty(auth) || string.IsNullOrEmpty(auth))
                throw new ArgumentNullException(nameof(auth), "auth header is empty");
            string jwt = auth[0]["Bearer ".Length..];

            if (string.IsNullOrEmpty(jwt) || jwt == "undefined")
                throw new ArgumentNullException(nameof(jwt), "jwt is empty");

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var claims = tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:ValidIssuer"],
                ValidateIssuer = true,
                ValidAudience = _configuration["Jwt:ValidAudience"],
                ValidateAudience = true,
                RequireExpirationTime = true,
            }, out var _);

            if (claims is null)
                throw new ArgumentNullException(nameof(claims), "Entry token is null");

            var user = await _userManager.FindByIdAsync(claims.FindFirstValue(ClaimTypes.NameIdentifier));
            return user;
        }
        public async Task CreateFullQuizAsync(QuizDTO quizDto)
        {
            var quiz = _mapper.Map<Quiz>(quizDto);
            var user = await GetOriginalCurrentUser();
            quiz.CreatorId = user.Id;

            for (int i = 0; i < quizDto.Questions.Count(); i++)
                quiz.Questions.ElementAt(i).Options = _mapper.Map<IEnumerable<Answer>>(quizDto.Questions[i].Options);
            await _context.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUserAsync(RegisterModelDTO registerModel)
        {
            if (registerModel is null)
                throw new ArgumentNullException(nameof(registerModel));

            var usernameExist = await _context.Users.AnyAsync(x => x.UserName == registerModel.Username);
            if (usernameExist == true)
                throw new DuplicateNameException("user with the given username already exists");

            var emailExist = await _context.Users.AnyAsync(x => x.Email == registerModel.Email);
            if (emailExist == true)
                throw new DuplicateNameException("user with the given email already exists");

             
            var user = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded == false)
                throw new InvalidOperationException("user was not created");
        }

        public async Task<UserDTO> GetCurrentUserAsync()
        {
            var user = await GetOriginalCurrentUser();
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task<UsersQuizzesDTO> GetQuizResultForCurrentUserAsync(int quizId)
        {
            var user = await GetOriginalCurrentUser();
            var usersQuizzes = await _context.UsersQuizzes
                .FirstOrDefaultAsync(x => x.CompletedQuizzesId == quizId && x.CompletedUsersId == user.Id);
            var usersQuizzesDto = _mapper.Map<UsersQuizzesDTO>(usersQuizzes);
            usersQuizzesDto.MaxScore = await _context.Questions.CountAsync(x => x.QuizId == quizId);
            if (usersQuizzesDto is null)
                throw new ArgumentNullException(nameof(quizId));
            return usersQuizzesDto;
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                await GetCurrentUserAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> IsQuizCompletedByCurrentUserAsync(int quizId)
        {
            var user = await GetOriginalCurrentUser();
            bool isCompleted = await _context.UsersQuizzes
                .AnyAsync(x => x.CompletedUsersId == user.Id && x.CompletedQuizzesId == quizId);
            return isCompleted;
        }

        public async Task<string> LoginAsync(LoginModelDTO loginModel)
        {
            if (loginModel is null)
                throw new ArgumentNullException(nameof(loginModel));

            ApplicationUser user;
            if (string.IsNullOrEmpty(loginModel.Username) == false)
                user = await _userManager.FindByNameAsync(loginModel.Username);
            else if (string.IsNullOrEmpty(loginModel.Email) == false)
                user = await _userManager.FindByEmailAsync(loginModel.Email);
            else throw new ArgumentNullException(nameof(loginModel), "username and email are empty");

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginModel.Password);
            if (user is not null && isPasswordCorrect)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:ValidIssuer"],
                    audience: _configuration["Jwt:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(120),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                var options = new CookieOptions
                {
                    HttpOnly = false,
                    Expires = DateTime.UtcNow.AddHours(6),
                    IsEssential = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                };

                _httpContext.HttpContext.Response.Cookies.Append("jwt", jwt, options);
                return jwt;
            }

            throw new UnauthorizedAccessException("username or password is incorrect");
        }

        public void Logout()
        {
            bool authExist = _httpContext.HttpContext
               .Request.Headers.TryGetValue("Authorization", out var auth);

            if (StringValues.IsNullOrEmpty(auth) || string.IsNullOrEmpty(auth) || authExist == false)
                throw new ArgumentNullException(nameof(auth), "auth header is empty");
            string jwt = auth[0]["Bearer ".Length..];

            if (string.IsNullOrEmpty(jwt))
                throw new UnauthorizedAccessException();

            _httpContext.HttpContext.Response.Cookies.Delete("jwt");
        }

        public async Task SetCompletedQuizToCurrentUserAsync(int quizId, int correctAnswers)
        {
            var user = await GetOriginalCurrentUser();

            await _context.UsersQuizzes.AddAsync(new ApplicationUserQuiz
            {
                CompletedQuizzesId = quizId,
                CompletedUsersId = user.Id,
                CorrectAnswers = correctAnswers
            });

            var quiz = await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == quizId);
            if (quiz is null)
                throw new ArgumentNullException(nameof(quizId));
            quiz.Passed++;
            _context.Quizzes.Update(quiz);

            await _context.SaveChangesAsync();
        }
    }
}
