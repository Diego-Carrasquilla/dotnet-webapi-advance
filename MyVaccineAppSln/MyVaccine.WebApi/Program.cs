using FluentValidation.AspNetCore;
using MyVaccine.WebApi.Configurations;
using MyVaccine.WebApi.Configurations.AutoMapperProfiles;
using MyVaccine.WebApi.Configuratios;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Repositories.Interfaces;
using MyVaccine.WebApi.Services;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Añadir controladores y configuración de FluentValidation
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de la base de datos
builder.Services.SetDatabaseConfiguration();

// Configuración de autenticación y autorización
builder.Services.SetMyyVaccineAuthConfiguration();

// Inyección de dependencias
builder.Services.SetDependencyInjection();

// Configuración de AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Servicios adicionales (solo para pruebas)
builder.Services.AddScoped<IGuidGeneratorScope, GuidServiceScope>();
builder.Services.AddTransient<IGuidGeneratorTrasient, GuidServiceTransient>();
builder.Services.AddSingleton<IGuidGeneratorSingleton, GuidServiceSingleton>();
builder.Services.AddScoped<IGuidGeneratorDeep, GuidGeneratorDeep>();

// Inyección de dependencias específicas para Allergy
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<IAllergyService, AllergyService>();

var app = builder.Build();

// Configure the HTTP request pipeline
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
