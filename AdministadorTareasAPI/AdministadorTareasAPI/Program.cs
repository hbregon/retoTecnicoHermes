using Microsoft.EntityFrameworkCore;
using AdministadorTareasAPI.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContexto>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql")));
builder.Services.AddControllers().AddJsonOptions(opciones =>
{
    opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Se activan las reglas CORS
var reglasCORS = "ReglasCORS";
builder.Services.AddCors(opcion =>
{
    opcion.AddPolicy(name: reglasCORS, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(reglasCORS);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
