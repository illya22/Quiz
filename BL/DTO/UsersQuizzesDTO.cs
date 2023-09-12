using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class UsersQuizzesDTO
    {
        public int CompletedUsersId { get; set; }

        public int CompletedQuizzesId { get; set; }

        public int CorrectAnswers { get; set; }

        public int MaxScore { get; set; }
    }
}
