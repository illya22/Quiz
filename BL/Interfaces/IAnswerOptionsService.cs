using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAnswerOptionsService
    {
        AnswerOptionsDTO GetByIdAsync(int id);
        void CreateAsync(AnswerOptionsDTO answerOptionsDTO);
        void UpdateAsync(AnswerOptionsDTO answerOptionsDTO);
        void DeleteAsync(int id);
    }
}
