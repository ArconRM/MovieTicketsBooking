using AutoMapper;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieDataService.AutoMapper;
using MovieDataService.Entities;
using MovieDataService.Repository;
using MovieDataService.Service;
using MovieDataService.Service.Interfaces;

//TODO: В один контекст все
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<IRepository<Person>, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddDbContext<MovieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("MovieServiceConnectionString").Value));
builder.Services.AddDbContext<PersonContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("PersonServiceConnectionString").Value));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();