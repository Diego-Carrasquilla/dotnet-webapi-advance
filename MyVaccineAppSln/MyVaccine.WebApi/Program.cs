using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Configuratios;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetDatabaseConfiguration();
builder.Services.SetMyyVaccineAuthConfiguration();
builder.Services.SetDependencyInjection();
builder.Services.AddScoped<IGuidGeneratorScope, GuidServiceScope>();
builder.Services.AddTransient<IGuidGeneratorTrasient, GuidServiceTransient>();
builder.Services.AddSingleton<IGuidGeneratorSingleton, GuidServiceSingleton>();
builder.Services.AddScoped<IGuidGeneratorDeep, GuidGeneratorDeep>();

builder.Services.AddControllers();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
