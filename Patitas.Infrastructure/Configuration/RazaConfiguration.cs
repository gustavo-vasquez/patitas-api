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
    internal class RazaConfiguration : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.HasData(
                new Raza() { Nombre = "Labrador Retriever", Id_Especie = 1 },
                new Raza() { Nombre = "Pastor Alemán", Id_Especie = 1 },
                new Raza() { Nombre = "Caniche", Id_Especie = 1 },
                new Raza() { Nombre = "Boxer", Id_Especie = 1 },
                new Raza() { Nombre = "Border Collie", Id_Especie = 1 },
                new Raza() { Nombre = "Golden Retriever", Id_Especie = 1 },
                new Raza() { Nombre = "Beagle", Id_Especie = 1 }
            );
        }
    }
}
