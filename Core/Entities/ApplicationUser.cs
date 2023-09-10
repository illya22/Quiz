using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<Quiz> CreatedQuizzes { get; set; }

        public virtual IEnumerable<ApplicationUserQuiz> CompletedQuizzes { get; set; }

        public ApplicationUser()
        {
            CreatedQuizzes = new List<Quiz>();
            CompletedQuizzes = new List<ApplicationUserQuiz>();
        }
    }
}
