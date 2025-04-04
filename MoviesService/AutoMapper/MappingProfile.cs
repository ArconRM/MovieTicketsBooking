using AutoMapper;
using Common.DTO;
using MoviesService.Entities;

namespace MoviesService.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieDTO>().ReverseMap();
    }
}