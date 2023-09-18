using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_COL_FechaCompletadoEnPlanDeVacunacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCompletado",
                table: "PlanesDeVacunacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCompletado",
                table: "PlanesDeVacunacion");
        }
    }
}
