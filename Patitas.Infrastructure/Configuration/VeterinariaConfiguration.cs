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
    internal class VeterinariaConfiguration : IEntityTypeConfiguration<Veterinaria>
    {
        public void Configure(EntityTypeBuilder<Veterinaria> builder)
        {
            builder.HasData(
                new Veterinaria()
                {
                    Id = 4,
                    Nombre = "Cuidado Animal",
                    RazonSocial = "Cuidado Animal S.A.",
                    Especialidades = "Vacunación, Cirugía, Ecografía, Peluquería",
                    FechaFundacion = DateTime.Parse("2012-10-28"),
                    HorarioApertura = "10",
                    HorarioCierre = "20"
                }
            );
        }
    }
}
