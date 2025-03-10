// dotnet add package Automapper
using AutoMapper;
namespace BoscComa.ADO 
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>(); 
            CreateMap<User, UserDTO>(); 
        }
    }
}