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
    internal class AdoptanteConfiguration : IEntityTypeConfiguration<Adoptante>
    {
        public void Configure(EntityTypeBuilder<Adoptante> builder)
        {
            builder.HasData(
                new Adoptante() { Id = 2, Nombre = "Adoptante", Apellido = "Test" }
            );
        }
    }
}
