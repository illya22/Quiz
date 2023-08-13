using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Like : BaseEntity
    {
        //navigation property( user-like)
        public int UserId { get; set; }
        public User User { get; set; }

        //navigation property( quiz-like)
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

    }
}
