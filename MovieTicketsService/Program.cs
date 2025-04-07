using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.AutoMapper;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository;
using MovieTicketsService.Service;
using MovieTicketsService.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Booking>, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddScoped<IRepository<MovieShow>, MovieShowRepository>();
builder.Services.AddScoped<IMovieShowService, MovieShowService>();

builder.Services.AddScoped<IRepository<ScreeningRoom>, ScreeningRoomRepository>();
builder.Services.AddScoped<IScreeningRoomService, ScreeningRoomService>();

builder.Services.AddScoped<IRepository<Seat>, SeatRepository>();
builder.Services.AddScoped<ISeatService, SeatService>();

builder.Services.AddScoped<IRepository<Theater>, TheaterRepository>();
builder.Services.AddScoped<ITheaterService, TheaterService>();

builder.Services.AddDbContext<MovieTicketsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();