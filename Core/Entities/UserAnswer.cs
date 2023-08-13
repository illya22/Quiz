using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserAnswer : BaseEntity
    {
<<<<<<< HEAD
        public int UserId { get; set; }
        public int AnswerOptionsId { get; set; }
        public DateTime Date { get; set; }
=======
        public DateTime Date { get; set; }

        //navigation property(user-userAnswer)
        public int UserId { get; set; }
        public User User { get; set; }

        //navigation property(answerOptions-userAnswer)
        public int AnswerOptionsId { get; set; }
        public AnswerOptions AnswerOptions { get; set; }
>>>>>>> 1ae529f6d7d64a97c793cd8d94eb38579e3efe6a
    }
}
