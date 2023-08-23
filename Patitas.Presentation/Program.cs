using Microsoft.EntityFrameworkCore;
using Patitas.Infrastructure;
using Patitas.Infrastructure.Contracts;
using Patitas.Infrastructure.Repositories;
using Patitas.Services;
using Patitas.Services.Contracts;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    /*.AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrego a la app el contexto "PatitasContext". Le digo que use sql server como motor y le paso el connection string que figura dentro de PatitasDB en appsettings.json 
builder.Services.AddDbContext<PatitasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PatitasDB"),
    sqlOptions => sqlOptions.MigrationsAssembly("Patitas.Infrastructure"))
);

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

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
