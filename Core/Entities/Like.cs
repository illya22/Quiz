using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Like : BaseEntity
    {
<<<<<<< HEAD
        public int UserId { get; set; }
        public int QuizId { get; set; }
=======
        //navigation property( user-like)
        public int UserId { get; set; }
        public User User { get; set; }

        //navigation property( quiz-like)
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
>>>>>>> 1ae529f6d7d64a97c793cd8d94eb38579e3efe6a

    }
}
