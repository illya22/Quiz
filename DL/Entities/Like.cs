using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Like:BaseEntity
    {
        public int User_Id { get; set; }
        public int Quiz_Id { get; set; }

    }
}
