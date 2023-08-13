using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Quiz : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation property( user-quiz)
        public int UserId { get; set; }
        public User User { get; set; }

        //navigation property(quiz-like)
        public ICollection<Like> Like { get; set; }

        //navigation property(quiz-category)
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //navigation property(quetion-quiz)
        public ICollection<Question> Question { get; set; }

    }
}
