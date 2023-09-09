using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_PlanDeVacunacionYVacunaDelPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprobada",
                table: "SolicitudesDeAdopcion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PlanesDeVacunacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_SolicitudDeAdopcion = table.Column<int>(type: "int", nullable: false),
                    Id_Veterinaria = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesDeVacunacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanesDeVacunacion_SolicitudesDeAdopcion_Id_SolicitudDeAdopcion",
                        column: x => x.Id_SolicitudDeAdopcion,
                        principalTable: "SolicitudesDeAdopcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanesDeVacunacion_Veterinarias_Id_Veterinaria",
                        column: x => x.Id_Veterinaria,
                        principalTable: "Veterinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacunasDelPlan",
                columns: table => new
                {
                    Id_PlanDeVacunacion = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false),
                    EstaCompleta = table.Column<bool>(type: "bit", nullable: false),
                    FechaDeCompletado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacunasDelPlan", x => new { x.Id_PlanDeVacunacion, x.Id_Vacuna });
                    table.ForeignKey(
                        name: "FK_VacunasDelPlan_PlanesDeVacunacion_Id_PlanDeVacunacion",
                        column: x => x.Id_PlanDeVacunacion,
                        principalTable: "PlanesDeVacunacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacunasDelPlan_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeVacunacion_Id_SolicitudDeAdopcion",
                table: "PlanesDeVacunacion",
                column: "Id_SolicitudDeAdopcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeVacunacion_Id_Veterinaria",
                table: "PlanesDeVacunacion",
                column: "Id_Veterinaria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacunasDelPlan_Id_Vacuna",
                table: "VacunasDelPlan",
                column: "Id_Vacuna");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacunasDelPlan");

            migrationBuilder.DropTable(
                name: "PlanesDeVacunacion");

            migrationBuilder.DropColumn(
                name: "Aprobada",
                table: "SolicitudesDeAdopcion");
        }
    }
}
