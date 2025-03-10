// dotnet add package Automapper
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserDTO, User>(); 
        CreateMap<User, UserDTO>(); 
    }
}
