using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AnswerOptions : BaseEntity
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        //navigation property(quetion-answerOptions)
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        //navigation property(answerOptions-userAnswer)
        public ICollection<UserAnswer> Answers { get; set; }

    }
}
