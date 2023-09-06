using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_NuevasColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAsignacion",
                table: "VeterinariasAsignadasARefugios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Veterinarias",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiasDeAtencion",
                table: "Veterinarias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "Veterinarias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstaActivo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Refugios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiasDeAtencion",
                table: "Refugios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "Refugios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "Animales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeAsignacion",
                table: "VeterinariasAsignadasARefugios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Veterinarias");

            migrationBuilder.DropColumn(
                name: "DiasDeAtencion",
                table: "Veterinarias");

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "Veterinarias");

            migrationBuilder.DropColumn(
                name: "EstaActivo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Refugios");

            migrationBuilder.DropColumn(
                name: "DiasDeAtencion",
                table: "Refugios");

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "Refugios");

            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "Animales");
        }
    }
}
