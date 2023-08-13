using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        //navigation property( user-role)
        public int RoleId { get; set; }
        public Role Role { get; set; }

        //navigation property( user-quiz)
        public ICollection<Quiz> Quiz { get; set; }
       
        //navigation property(user-like)
        public ICollection<Like> Like { get; set; }

        //navigation property(user-userAnswer)
        public ICollection<UserAnswer> UserAnswer { get; set; }
    }
}
