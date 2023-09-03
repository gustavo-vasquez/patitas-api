using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_EspecieVacuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiereDosisDeRefuerzo",
                table: "Vacunas");

            migrationBuilder.RenameColumn(
                name: "EdadAproximada",
                table: "Vacunas",
                newName: "EdadIndicada");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeAplicacion",
                table: "AnimalVacuna",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NroDosisAplicada",
                table: "AnimalVacuna",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EspecieVacuna",
                columns: table => new
                {
                    Id_Especie = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieVacuna", x => new { x.Id_Especie, x.Id_Vacuna });
                    table.ForeignKey(
                        name: "FK_EspecieVacuna_Especies_Id_Especie",
                        column: x => x.Id_Especie,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecieVacuna_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspecieVacuna_Id_Vacuna",
                table: "EspecieVacuna",
                column: "Id_Vacuna");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspecieVacuna");

            migrationBuilder.DropColumn(
                name: "FechaDeAplicacion",
                table: "AnimalVacuna");

            migrationBuilder.DropColumn(
                name: "NroDosisAplicada",
                table: "AnimalVacuna");

            migrationBuilder.RenameColumn(
                name: "EdadIndicada",
                table: "Vacunas",
                newName: "EdadAproximada");

            migrationBuilder.AddColumn<bool>(
                name: "RequiereDosisDeRefuerzo",
                table: "Vacunas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
