using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
       private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/questions?quizid=1
        [HttpGet]
        public async Task<IActionResult> GetQuizId([FromQuery] int quizId)
        {
            try
            {
                var question = await _questionService.GetQuestionsByQuizIdAsync(quizId);
                return Ok(question);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
