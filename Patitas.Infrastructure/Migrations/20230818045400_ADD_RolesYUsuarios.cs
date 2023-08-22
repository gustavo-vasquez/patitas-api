using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_RolesYUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, null, "cosme.fulanito@gmail.com", new DateTime(2023, 8, 18, 1, 54, 0, 73, DateTimeKind.Local).AddTicks(7497), null, 4, 1, "Cosme_Fulanito", "asd123", null },
                    { 2, null, "admin.patitas@gmail.com", new DateTime(2023, 8, 18, 1, 54, 0, 73, DateTimeKind.Local).AddTicks(7509), null, 3, 2, "Administrador", "asd123", null },
                    { 3, null, "refugio_sanpedro@gmail.com", new DateTime(2023, 8, 18, 1, 54, 0, 73, DateTimeKind.Local).AddTicks(7511), null, 2, 3, "Refugio.San.Pedro", "asd123", null },
                    { 4, null, "picaduras_oficial@gmail.com", new DateTime(2023, 8, 18, 1, 54, 0, 73, DateTimeKind.Local).AddTicks(7512), null, 1, 4, "Picaduras", "asd123", null }
                });

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "EsFundador" },
                values: new object[] { 2, true });

            migrationBuilder.InsertData(
                table: "Adoptantes",
                columns: new[] { "Id", "Apellido", "DNI", "FechaNacimiento", "Nombre" },
                values: new object[] { 1, "Fulanito", null, null, "Cosme" });

            migrationBuilder.InsertData(
                table: "Refugios",
                columns: new[] { "Id", "ApellidoResponsable", "HorarioApertura", "HorarioCierre", "Nombre", "NombreResponsable", "RazonSocial", "SitioWeb" },
                values: new object[] { 3, "Simpson", "09", "14", "San Pedro", "Homero", "Refugio San Pedro S.A.", null });

            migrationBuilder.InsertData(
                table: "Veterinarias",
                columns: new[] { "Id", "Especialidades", "FechaFundacion", "HorarioApertura", "HorarioCierre", "Nombre", "RazonSocial", "SitioWeb", "TelefonoAlternativo" },
                values: new object[] { 4, "Vacunación, Cirugía, Ecografía, Peluquería", new DateTime(2012, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "10", "20", "Picaduras", "Picaduras S.R.L.", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administradores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adoptantes",
                keyColumn: "Id",
                keyValue: 1);

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
