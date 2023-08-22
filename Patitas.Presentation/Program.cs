using Microsoft.EntityFrameworkCore;
using Patitas.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agrego a la app el contexto "PatitasContext". Le digo que use sql server como motor y le paso el connection string que figura dentro de PatitasDB en appsettings.json 
builder.Services.AddDbContext<PatitasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PatitasDB"),
    sqlOptions => sqlOptions.MigrationsAssembly("Patitas.Infrastructure"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
