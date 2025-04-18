using AutoMapper;
using Common.DTO;
using MovieDataService.Entities;

namespace MovieDataService.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieDTO>().ReverseMap();
        CreateMap<Person, PersonDTO>().ReverseMap();
        CreateMap<Genre, GenreDTO>().ReverseMap();
    }
}