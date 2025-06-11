using Core.Interfaces;
using EventsService.Interfaces;
using EventsService.RabbitMQ;
using EventsService.RabbitMQ.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService;
using MovieTicketsService.AutoMapper;
using MovieTicketsService.Entities;
using MovieTicketsService.EventHandling;
using MovieTicketsService.Repository;
using MovieTicketsService.Service;
using MovieTicketsService.Service.Interfaces;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcClients(builder.Configuration);

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

builder.Services.AddSingleton<IRabbitMqConnectionProvider, RabbitMqConnectionProvider>();
builder.Services.AddSingleton<IEventPublisher, RabbitMqEventPublisher>();
builder.Services.AddSingleton<IEventSubscriber, RabbitMqEventSubscriber>();

builder.Services.AddSingleton<UserSuspendedOrBannedEventHandler>();
builder.Services.AddHostedService<MovieTicketsBackgroundService>();

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

// app.UseHttpsRedirection();
app.MapControllers();
app.Run();