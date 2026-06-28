using Microsoft.EntityFrameworkCore;
using ApiEcommerce.Repository;
using ApiEcommerce.Mapping;
using Scalar.AspNetCore;

DotNetEnv.Env.Load(); // carga las variables del archivo .env

var builder = WebApplication.CreateBuilder(args); // crea el builder para configurar la app

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //AddScope es para que cada vez que se solicite un ICategoryRepository se cree una nueva instancia
builder.Services.AddScoped<CategoryMapper>(); //AddScope es para que cada vez que se solicite un CategoryMapper se cree una nueva instancia

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"))); // agrega el contexto de la base de datos

builder.Services.AddControllers(); // habilita los controladores (endpoints API)

builder.Services.AddOpenApi(); // agrega soporte para documentación OpenAPI

var app = builder.Build(); // construye la app con los servicios configurados

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // solo en entorno de desarrollo
{
    app.MapOpenApi(); // expone el endpoint con el documento OpenAPI
    app.MapScalarApiReference(); // UI interactiva en /scalar/v1
}

app.UseHttpsRedirection(); // redirige las peticiones HTTP a HTTPS

app.UseAuthorization(); // habilita el middleware de autorización

app.MapControllers(); // mapea las rutas a los controladores

app.Run(); // inicia la aplicación
