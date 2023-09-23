using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizzesController : Controller
    {
        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET: /api/quizzes/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var quizzes = await _quizService.GetAllAsync();
                return Ok(quizzes);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /api/quizzes/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var quiz = await _quizService.GetByIdAsync(id);
                return Ok(quiz);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /api/quizzes/get-quizzes-by-creator?username=user01
        [HttpGet("get-quizzes-by-creator")]
        public async Task<IActionResult> GetQuizzesByCreator([FromQuery] string username)
        {
            try
            {
                var quizzes = await _quizService.GetQuizzesByCreatorAsync(username);
                return Ok(quizzes);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: /api/quizzes/get-quizzes-by-passed-user?username=user01
        [HttpGet("get-quizzes-by-passed-user")]
        public async Task<IActionResult> GetQuizzesByPassedUsers([FromQuery] string username)
        {
            try
            {
                var quizzes = await _quizService.GetQuizzesByPassedUsersAsync(username);
                return Ok(quizzes);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: /api/quizzes/get-passed-users-by-quizid?quizid=1
        [HttpGet("get-users-by-passed-quizid")]
        public async Task<IActionResult> GetUserByPassedQuiz([FromQuery] int quizId)
        {
            try
            {
                var quizzes = await _quizService.GetUserByPassedQuizAsync(quizId);
                return Ok(quizzes); 
            }
            catch 
            { 
                return BadRequest(); 
            }
        }

        // GET: /api/quizzes/get-result-by-username?username=user01&quizid=1
        [HttpGet("get-result-by-username")]
        public async Task<IActionResult> GetResultByUserName([FromQuery] string username, [FromQuery] int quizId)
        {
            try
            {
                var result = await _quizService.GetResultByUserNameAsync(username, quizId);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
