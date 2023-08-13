using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserAnswerService
    {
        UserAnswerDTO GetByIdAsync(int id);
        void CreateAsync (UserAnswerDTO userAnswerDTO);
    }
}
