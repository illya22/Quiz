using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        UserDTO GetByIdAsync (int id);
        void CreateAsync (UserDTO user);
        void UpdateAsync (UserDTO user);
        void DeleteAsync (int id);
    }
}
