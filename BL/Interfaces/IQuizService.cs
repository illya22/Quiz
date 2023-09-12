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
        Task<IEnumerable<QuizDTO>> GetAllAsync();
        Task<QuizDTO> GetByIdAsync(int id);
        Task<IEnumerable<QuizDTO>> GetQuizzesByCreatorAsync(string username);
        Task<IEnumerable<QuizDTO>> GetQuizzesByPassedUsersAsync(string username);
        Task<IEnumerable<UserDTO>> GetUserByPassedQuizAsync(int quizid);
        Task<UsersQuizzesDTO> GetResultByUserNameAsync(string username, int quizId);
    }
}
