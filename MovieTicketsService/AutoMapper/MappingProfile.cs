using AutoMapper;
using Common.DTO.MovieTickets;
using MovieTicketsService.Entities;

namespace MovieTicketsService.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Booking, BookingWithIdsDTO>().ReverseMap();
        CreateMap<Booking, BookingFullDTO>().ReverseMap();

        CreateMap<MovieShow, MovieShowWithIdsDTO>().ReverseMap();
        CreateMap<MovieShow, MovieShowFullDTO>().ReverseMap();

        CreateMap<ScreeningRoom, ScreeningRoomWithIdsDTO>().ReverseMap();
        CreateMap<ScreeningRoom, ScreeningRoomFullDTO>().ReverseMap();

        CreateMap<Seat, SeatWithIdsDTO>().ReverseMap();
        CreateMap<Seat, SeatFullDTO>().ReverseMap();

        CreateMap<Theater, TheaterDTO>().ReverseMap();
    }
}