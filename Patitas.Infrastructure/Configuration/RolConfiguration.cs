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
    internal class RolConfiguration : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> builder)
        {
            builder.HasData(
                new RolUsuario() { Id = 1, Nombre = "Administrador" },
                new RolUsuario() { Id = 2, Nombre = "Adoptante" },
                new RolUsuario() { Id = 3, Nombre = "Refugio" },
                new RolUsuario() { Id = 4, Nombre = "Veterinaria" }
            );
        }
    }
}
