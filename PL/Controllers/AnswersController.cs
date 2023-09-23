using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController : Controller
    {
        private readonly IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        // GET: api/answers?quizid=1
        [HttpGet]
        public async Task<IActionResult> GetAnswerByQuizId([FromQuery] int quizId)
        {
            try
            {
                var answer = await _answerService.GetAnswersByQuizIdAsync(quizId);
                return Ok(answer);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
