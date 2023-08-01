using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Quiz:BaseEntity
    {
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category_Id { get; set; }
    }
}
