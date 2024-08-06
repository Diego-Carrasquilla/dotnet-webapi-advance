using FluentValidation.AspNetCore;
using MyVaccine.WebApi.Configuratios;
using MyVaccine.WebApi.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// A�adir controladores y configuraci�n de FluentValidation
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de la base de datos
builder.Services.SetDatabaseConfiguration();

// Configuraci�n de autenticaci�n y autorizaci�n
builder.Services.SetMyyVaccineAuthConfiguration();

// Inyecci�n de dependencias
builder.Services.SetDependencyInjection();

// Configuraci�n de AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Servicios adicionales (solo para pruebas)
builder.Services.AddScoped<IGuidGeneratorScope, GuidServiceScope>();
builder.Services.AddTransient<IGuidGeneratorTrasient, GuidServiceTransient>();
builder.Services.AddSingleton<IGuidGeneratorSingleton, GuidServiceSingleton>();
builder.Services.AddScoped<IGuidGeneratorDeep, GuidGeneratorDeep>();

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
