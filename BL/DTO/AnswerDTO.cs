using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; } = false;
    }
}
