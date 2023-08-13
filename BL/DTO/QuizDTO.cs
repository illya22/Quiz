using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<LikeDTO> Likes { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
    }
}
