using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category : BaseEntity
    {
<<<<<<< HEAD

        public string Name { get; set; }
    }
}
=======
        public string Name { get; set; }

        //navigation property(quiz-category)
        public ICollection<Quiz> Quiz { get; set; }
    }
}
 
>>>>>>> 1ae529f6d7d64a97c793cd8d94eb38579e3efe6a
