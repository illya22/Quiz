using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities
{
    public class Question:BaseEntity
    {
        public int Quiz_Id { get; set; }
        public string Question_Text { get; set; }
    }
}
