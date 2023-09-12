using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public QuestionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QuestionDTO>> GetQuestionsByQuizIdAsync(int quizId)
        {
            var questions = await _context.Questions.Where(x => x.QuizId == quizId).ToListAsync();
            var questionDTO = _mapper.Map<IEnumerable<QuestionDTO>>(questions);
            return questionDTO;
        }
    }
}
