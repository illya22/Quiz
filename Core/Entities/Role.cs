using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
<<<<<<< HEAD
=======

        //navigation property
        public ICollection<User> User { get; set; }
>>>>>>> 1ae529f6d7d64a97c793cd8d94eb38579e3efe6a
    }
}
