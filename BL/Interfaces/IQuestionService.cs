using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IQuestionService
    {
        QuestionDTO GetByIdAsync(int id);
        void CreateAsync (QuestionDTO question);
        void UpdateAsync (QuestionDTO question);
        void DeleteAsync (int id);
    }
}
