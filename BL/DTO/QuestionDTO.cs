using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public int QuizId { get; set; }

        public IEnumerable<AnswerDTO> Options { get; set; } = new List<AnswerDTO>();
    }
}
