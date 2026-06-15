using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // crea el builder para configurar la app

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"))); // agrega el contexto de la base de datos

builder.Services.AddControllers(); // habilita los controladores (endpoints API)

builder.Services.AddOpenApi(); // agrega soporte para documentación OpenAPI

var app = builder.Build(); // construye la app con los servicios configurados

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // solo en entorno de desarrollo
{
    app.MapOpenApi(); // expone el endpoint con el documento OpenAPI
}

app.UseHttpsRedirection(); // redirige las peticiones HTTP a HTTPS

app.UseAuthorization(); // habilita el middleware de autorización

app.MapControllers(); // mapea las rutas a los controladores

app.Run(); // inicia la aplicación
