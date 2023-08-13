using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class AnswerOptionsDTO
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
