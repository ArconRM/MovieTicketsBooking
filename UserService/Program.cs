using Core.Interfaces;
using EventsService.Events;
using EventsService.Interfaces;
using EventsService.RabbitMQ;
using EventsService.RabbitMQ.Interfaces;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserService;
using UserService.AutoMapper;
using UserService.Entities;
using UserService.EventHandlers;
using UserService.Extensions;
using UserService.GrpcServices;
using UserService.Repository;
using UserService.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrelWithOptions();

builder.Services.AddControllers();
builder.Services.AddGrpc();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService.Service.UserService>();

builder.Services.AddScoped<BookingAbandonedEventHandler>();

builder.Services.AddSingleton<IRabbitMqConnectionProvider, RabbitMqConnectionProvider>();
builder.Services.AddSingleton<IEventPublisher, RabbitMqEventPublisher>();
builder.Services.AddSingleton<IEventSubscriber, RabbitMqEventSubscriber>();

builder.Services.AddHostedService<UserBackgroundService>();

builder.Services.AddDbContext<UserContext>(options =>
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

app.MapGrpcService<UserGrpcService>();

app.Run();