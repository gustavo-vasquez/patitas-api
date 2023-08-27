using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SEED_BarrioRolUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barrios",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Congreso" },
                    { 2, "Palermo" },
                    { 3, "Puerto Madero" },
                    { 4, "Recoleta" }
                });

            migrationBuilder.InsertData(
                table: "RolesUsuario",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Adoptante" },
                    { 3, "Refugio" },
                    { 4, "Veterinaria" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Direccion", "Email", "FechaCreacion", "FotoDePerfil", "Id_Barrio", "Id_RolUsuario", "NombreUsuario", "Password", "Telefono" },
                values: new object[,]
                {
                    { 1, null, "admin.patitas@gmail.com", new DateTime(2023, 8, 26, 18, 10, 12, 303, DateTimeKind.Local).AddTicks(3914), null, 3, 1, "administrador", "asd123", null },
                    { 2, null, "adoptante.test@gmail.com", new DateTime(2023, 8, 26, 18, 10, 12, 303, DateTimeKind.Local).AddTicks(3924), null, 4, 2, "adoptante.test", "asd123", null },
                    { 3, null, "refugio_sanpedro@gmail.com", new DateTime(2023, 8, 26, 18, 10, 12, 303, DateTimeKind.Local).AddTicks(3926), null, 1, 3, "san.pedro", "asd123", null },
                    { 4, null, "cuidado_animal_oficial@gmail.com", new DateTime(2023, 8, 26, 18, 10, 12, 303, DateTimeKind.Local).AddTicks(3927), null, 2, 4, "cuidado_animal", "asd123", null }
                });

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "EsFundador" },
                values: new object[] { 1, true });

            migrationBuilder.InsertData(
                table: "Adoptantes",
                columns: new[] { "Id", "Apellido", "DNI", "FechaNacimiento", "Nombre" },
                values: new object[] { 2, "Test", null, null, "Adoptante" });

            migrationBuilder.InsertData(
                table: "Refugios",
                columns: new[] { "Id", "ApellidoResponsable", "HorarioApertura", "HorarioCierre", "Nombre", "NombreResponsable", "RazonSocial", "SitioWeb" },
                values: new object[] { 3, "Simpson", "09", "14", "San Pedro", "Homero", "Refugio San Pedro S.A.", null });

            migrationBuilder.InsertData(
                table: "Veterinarias",
                columns: new[] { "Id", "Especialidades", "FechaFundacion", "HorarioApertura", "HorarioCierre", "Nombre", "RazonSocial", "SitioWeb", "TelefonoAlternativo" },
                values: new object[] { 4, "Vacunación, Cirugía, Ecografía, Peluquería", new DateTime(2012, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "10", "20", "Cuidado Animal", "Cuidado Animal S.A.", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administradores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adoptantes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Refugios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Veterinarias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Barrios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Barrios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Barrios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Barrios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolesUsuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolesUsuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolesUsuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolesUsuario",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
