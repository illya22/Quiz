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

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CreatorId { get; set; }

        public UserDTO? Author { get; set; }

        public int Passed { get; set; } = 0;

        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();
    }
}
