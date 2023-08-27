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
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
                new Usuario() { Id = 1, NombreUsuario = "administrador", Email = "admin.patitas@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 3, Id_RolUsuario = 1 },
                new Usuario() { Id = 2, NombreUsuario = "adoptante.test", Email = "adoptante.test@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 4, Id_RolUsuario = 2 },
                new Usuario() { Id = 3, NombreUsuario = "san.pedro", Email = "refugio_sanpedro@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 1, Id_RolUsuario = 3 },
                new Usuario() { Id = 4, NombreUsuario = "cuidado_animal", Email = "cuidado_animal_oficial@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 2, Id_RolUsuario = 4 }
            );
        }
    }
}
