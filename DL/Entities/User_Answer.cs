using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class User_Answer : BaseEntity
    {
        public int User_Id { get; set; }
        public int Answer_Options_Id { get; set; }
        public DateTime Date { get; set; }
    }
}
