using AutoMapper;
using Common.DTO;
using Common.DTO.MovieTickets;
using MovieTicketsService.Entities;

namespace MovieTicketsService.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Booking, BookingDTO>().ReverseMap();
        CreateMap<MovieShow, MovieShowDTO>().ReverseMap();
        CreateMap<ScreeningRoom, ScreeningRoomDTO>().ReverseMap();
        CreateMap<Seat, SeatDTO>().ReverseMap();
        CreateMap<Theater, TheaterDTO>().ReverseMap();
    }
}