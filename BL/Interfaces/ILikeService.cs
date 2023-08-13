using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ILikeService
    {
        LikeDTO GetByUserIdAsync(int userId);
        LikeDTO GetByQuizIdAsync(int quizId);
        void AddAsync (LikeDTO like);
        void DeletedAsync (int id);
    }
}
