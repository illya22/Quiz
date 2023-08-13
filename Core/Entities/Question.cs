using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }

        //navigation property(quetion-quiz)
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        //navigation property(quetion-answerOptions)
        public ICollection<AnswerOptions> Options { get; set; }
    }
}
