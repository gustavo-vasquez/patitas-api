using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Configuration
{
    internal class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData(
                new Animal()
                {
                    Nombre = "Coco",
                    Nacimiento = 2022,
                    Genero = 'M',
                    SituacionPrevia = "Fue rescatado de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Toby",
                    Nacimiento = 2022,
                    Genero = 'M',
                    SituacionPrevia = "Fue rescatado de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Simba",
                    Nacimiento = 2022,
                    Genero = 'M',
                    SituacionPrevia = "Fue rescatado de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Tom",
                    Nacimiento = 2022,
                    Genero = 'M',
                    SituacionPrevia = "Fue rescatado de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Mia",
                    Nacimiento = 2022,
                    Genero = 'H',
                    SituacionPrevia = "Fue rescatada de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Maya",
                    Nacimiento = 2022,
                    Genero = 'H',
                    SituacionPrevia = "Fue rescatada de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Luna",
                    Nacimiento = 2022,
                    Genero = 'H',
                    SituacionPrevia = "Fue rescatada de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                },
                new Animal()
                {
                    Nombre = "Morena",
                    Nacimiento = 2022,
                    Genero = 'H',
                    SituacionPrevia = "Fue rescatada de la calle",
                    Altura = 55M,
                    Esterilizado = false,
                    Desparasitado = true,
                    FechaIngreso = DateTime.Now,
                    EstaAdoptado = false,
                    Id_Raza = 1,
                    Id_Refugio = 1
                }
            );
        }
    }
}
