using AutoMapper;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MoviesService.AutoMapper;
using MoviesService.Entities;
using MoviesService.Repository;
using MoviesService.Repository.Interfaces;
using MoviesService.Services;
using MoviesService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddDbContext<MovieContext>(options => options.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value));

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
