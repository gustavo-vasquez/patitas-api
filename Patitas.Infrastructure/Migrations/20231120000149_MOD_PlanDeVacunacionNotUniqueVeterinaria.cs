using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOD_PlanDeVacunacionNotUniqueVeterinaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlanesDeVacunacion_Id_Veterinaria",
                table: "PlanesDeVacunacion");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeVacunacion_Id_Veterinaria",
                table: "PlanesDeVacunacion",
                column: "Id_Veterinaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlanesDeVacunacion_Id_Veterinaria",
                table: "PlanesDeVacunacion");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeVacunacion_Id_Veterinaria",
                table: "PlanesDeVacunacion",
                column: "Id_Veterinaria",
                unique: true);
        }
    }
}
