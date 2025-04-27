using AutoMapper;
using Common.DTO;
using Common.DTO.User;
using UserService.Entities;

namespace UserService.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}