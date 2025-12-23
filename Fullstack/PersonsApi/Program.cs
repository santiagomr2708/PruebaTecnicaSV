using FluentValidation;
using FluentValidation.AspNetCore;
using PersonsApi.Repositories;
using PersonsApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorio en memoria
builder.Services.AddSingleton<IPersonRepository, InMemoryPersonRepository>();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PersonCreateValidator>();

// CORS para permitir al frontend consumir la API
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Mapear controladores
app.MapControllers();

app.Run();
