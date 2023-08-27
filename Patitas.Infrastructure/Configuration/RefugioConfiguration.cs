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
    internal class RefugioConfiguration : IEntityTypeConfiguration<Refugio>
    {
        public void Configure(EntityTypeBuilder<Refugio> builder)
        {
            builder.HasData(
                new Refugio()
                {
                    Id = 3,
                    Nombre = "San Pedro",
                    RazonSocial = "Refugio San Pedro S.A.",
                    NombreResponsable = "Homero",
                    ApellidoResponsable = "Simpson",
                    HorarioApertura = "09",
                    HorarioCierre = "14"
                }
            );
        }
    }
}
