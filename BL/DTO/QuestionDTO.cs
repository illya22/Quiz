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
        public string QuestionText { get; set; }
        public int QuizId { get; set; }
        public ICollection<AnswerOptionsDTO> Options { get; set; }
    }
}
