using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO loginModel)
        {
            try
            {
                var jwt = await _userService.LoginAsync(loginModel);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDTO registerModel)
        {
            try
            {
                await _userService.CreateUserAsync(registerModel);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var user = await _userService.GetCurrentUserAsync();
                return Ok(user);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try
            {
                _userService.Logout();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("is-authenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            return Ok(await _userService.IsAuthenticatedAsync());
        }

        // POST: api/users/set-completed-quiz?quizid=1&correctanswers=4
        [HttpPost("set-completed-quiz")]
        public async Task<IActionResult> SetCompletedQuizToCurrentUser([FromQuery] int quizId, [FromQuery] int correctAnswers)
        {
            if (await _userService.IsAuthenticatedAsync() == false)
                return Unauthorized();

            try
            {
                await _userService.SetCompletedQuizToCurrentUserAsync(quizId, correctAnswers);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/users/is-quiz-completed-by-current-user
        [HttpGet("is-quiz-completed-by-current-user")]
        public async Task<IActionResult> IsQuizCompletedByCurrentUser([FromQuery] int quizId)
        {
            if(await _userService.IsAuthenticatedAsync() == false)
                return Unauthorized();

            try
            {
                bool isCompleted = await _userService.IsQuizCompletedByCurrentUserAsync(quizId);
                return Ok(isCompleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/users/get-user-by-username?username=user01
        [HttpGet("get-user-by-username")]
        public async Task<IActionResult> GetUserByUsername([FromQuery] string username)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/users/create-quiz
        [HttpPost("create-quiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] QuizDTO quizDTO)
        {
            try
            {
                await _userService.CreateFullQuizAsync(quizDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
