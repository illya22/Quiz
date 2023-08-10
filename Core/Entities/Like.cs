using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Like : BaseEntity
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }

    }
}
