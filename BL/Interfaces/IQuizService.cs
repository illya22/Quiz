using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IQuizService
    {
        QuizDTO GetByIdAsync(int id);
        void CreateAsync (QuizDTO quiz);
        void UpdateAsync (QuizDTO quiz);
        void DeleteAsync (QuizDTO quiz);
    }
}
