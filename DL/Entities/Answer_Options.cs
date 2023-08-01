using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Answer_Options:BaseEntity
    {
        public int Question_Id { get; set; }
        public string Answer_Text { get; set; }
        public bool Is_Correct { get; set; }
    }
}
