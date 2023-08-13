using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class LikeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
    }
}
