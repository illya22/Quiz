using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace BusinessLayer.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AnswerService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AnswerDTO>> GetAnswersByQuizIdAsync(int quizId)
        {
            var questions = await _context.Questions
                .Where(x => x.QuizId == quizId)
                .ToListAsync();
            var answersDto = new List<AnswerDTO>();
            foreach (var question in questions)
            {
                var answers = await _context.Answers
                    .Where(x => x.QuestionId == question.Id)
                    .ToListAsync();
                answersDto.AddRange(_mapper.Map<List<AnswerDTO>>(answers));
            }
            return answersDto;
        }
    }
}
