using BusinessLayer.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync(RegisterModelDTO registerModel);

        public Task<string> LoginAsync(LoginModelDTO loginModel);

        public Task<UserDTO> GetCurrentUserAsync();

        public Task<bool> IsAuthenticatedAsync();

        public void Logout();

        Task SetCompletedQuizToCurrentUserAsync(int quizId, int correctAnswers);

        Task<bool> IsQuizCompletedByCurrentUserAsync(int quizId);

        Task<UsersQuizzesDTO> GetQuizResultForCurrentUserAsync(int quizId);

        Task<UserDTO> GetUserByUsernameAsync(string username);

        Task CreateFullQuizAsync(QuizDTO quizDto);
    }
}
