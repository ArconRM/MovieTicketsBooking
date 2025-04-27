using AutoMapper;
using Common.DTO;
using Common.DTO.MovieData;
using MovieDataService.Entities;

namespace MovieDataService.AutoMapper;

//TODO: список сущностей с только гуидниками
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovieFullDTO, Movie>().ReverseMap();
        CreateMap<MovieDisplayDTO, Movie>().ReverseMap();

        CreateMap<MovieWithIdsDTO, Movie>()
            .ForMember(
                dest => dest.Genres,
                opt => opt.MapFrom(src => src.GenresIds.Select(u => new Genre() { UUID = u }))
            )
            .ForMember(
                dest => dest.Actors,
                opt => opt.MapFrom(src => src.ActorsIds.Select(u => new Actor() { UUID = u }))
            )
            .ReverseMap();

        CreateMap<ActorDTO, Actor>().ReverseMap();
        CreateMap<ProducerDTO, Producer>().ReverseMap();
        CreateMap<GenreDTO, Genre>().ReverseMap();
    }
}