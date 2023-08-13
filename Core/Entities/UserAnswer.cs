using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserAnswer : BaseEntity
    {
        public DateTime Date { get; set; }

        //navigation property(user-userAnswer)
        public int UserId { get; set; }
        public User User { get; set; }

        //navigation property(answerOptions-userAnswer)
        public int AnswerOptionsId { get; set; }
        public AnswerOptions AnswerOptions { get; set; }
    }
}
