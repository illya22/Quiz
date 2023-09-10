using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApplicationUserQuiz
    {
        public int CompletedQuizzesId { get; set; }

        public Quiz? Quiz { get; set; }

        public int CompletedUsersId { get; set; }

        public ApplicationUser? User { get; set; }

        public int CorrectAnswers { get; set; }
    }
}
