using AutoMapper;
using BusinessLayer.DTO;
using Core.Entities;
using System.Threading.Tasks.Sources;

namespace BusinessLayer
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AnswerDTO, Answer>().ReverseMap();
            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<QuizDTO, Quiz>().ReverseMap();
            CreateMap<UserDTO, ApplicationUser>().ReverseMap();
            CreateMap<UsersQuizzesDTO,ApplicationUserQuiz>().ReverseMap();
        }
    }
}
