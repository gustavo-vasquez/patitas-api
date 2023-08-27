using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Configuration
{
    internal class BarrioConfiguration : IEntityTypeConfiguration<Barrio>
    {
        public void Configure(EntityTypeBuilder<Barrio> builder)
        {
            builder.HasData(
                new Barrio() { Id = 1, Nombre = "Congreso" },
                new Barrio() { Id = 2, Nombre = "Palermo" },
                new Barrio() { Id = 3, Nombre = "Puerto Madero" },
                new Barrio() { Id = 4, Nombre = "Recoleta" }
            );
        }
    }
}
