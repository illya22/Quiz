using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using Core.Entities;
using DL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class QuizService : IQuizService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public QuizService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QuizDTO>> GetAllAsync()
        {
            var quizzes = await _context.Quizzes.ToListAsync();
            var quizzesDto = _mapper.Map<IEnumerable<QuizDTO>>(quizzes);

            quizzesDto = quizzesDto.Select(q =>
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == q.CreatorId);
                q.Author = _mapper.Map<UserDTO>(user);
                return q;
            });

            return quizzesDto;
        }

        public async Task<QuizDTO> GetByIdAsync(int id)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == id);
            if (quiz is null)
                throw new ArgumentNullException(nameof(id), "there is no  quiz with the following id");

            var quizDto = _mapper.Map<QuizDTO>(quiz);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == quizDto.CreatorId);
            quizDto.Author = _mapper.Map<UserDTO>(user);

            return quizDto;
        }

        public async Task<IEnumerable<QuizDTO>> GetQuizzesByCreatorAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            var quizzes = await _context.Quizzes.Where(x => x.CreatorId == user.Id).ToListAsync();
            var quizzesDto = _mapper.Map<IEnumerable<QuizDTO>>(quizzes);
            foreach (var quiz in quizzesDto)
                quiz.Author = _mapper.Map<UserDTO>(user);
            return quizzesDto;
        }

        public async Task<IEnumerable<QuizDTO>> GetQuizzesByPassedUsersAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            var usersQuizzes = await _context.UsersQuizzes.Where(x => x.CompletedUsersId == user.Id).ToListAsync();
            var quizzIds = usersQuizzes.Select(x => x.CompletedQuizzesId);
            List<QuizDTO> quizzes = new();
            foreach (var id in quizzIds)
            {
                var quiz = await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == id);
                var quizDto = _mapper.Map<QuizDTO>(quiz);
                var author = await _context.Users.FirstOrDefaultAsync(x => x.Id == quiz.CreatorId);
                quizDto.Author = _mapper.Map<UserDTO>(author);
                quizzes.Add(quizDto);
            }
            return quizzes;
        }

        public async Task<UsersQuizzesDTO> GetResultByUserNameAsync(string username, int quizId)
        {
            var userid = (await _context.Users.FirstOrDefaultAsync(x => x.UserName == username)).Id;
            var userQuiz = await _context.UsersQuizzes.FirstOrDefaultAsync(x => x.CompletedQuizzesId == quizId && x.CompletedUsersId == userid);
            var userQuizDto = _mapper.Map<UsersQuizzesDTO>(userQuiz);
            return userQuizDto;
        }

        public async Task<IEnumerable<UserDTO>> GetUserByPassedQuizAsync(int quizid)
        {
            var userQuizzes = await _context.UsersQuizzes.Where(x => x.CompletedQuizzesId == quizid).ToListAsync();
            List<UserDTO> users = new();
            foreach (var userQuiz in userQuizzes)
                users.Add(_mapper.Map<UserDTO>(await _context.Users.FirstOrDefaultAsync(x => x.Id == userQuiz.CompletedUsersId)));
            return users;
        }
    }
}
