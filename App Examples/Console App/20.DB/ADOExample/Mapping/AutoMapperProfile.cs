// dotnet add package Automapper
using AutoMapper;
using BoscComa.DTO;

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