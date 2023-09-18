using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOD_COL_PlanSeguimientoVacunaDelPlanAnimalVacuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaCompleta",
                table: "VacunasDelPlan");

            migrationBuilder.RenameColumn(
                name: "FechaDeCompletado",
                table: "VacunasDelPlan",
                newName: "FechaDeAplicacion");

            migrationBuilder.RenameColumn(
                name: "FechaDeAsignacion",
                table: "SeguimientosDeVacunacion",
                newName: "FechaAsignada");

            migrationBuilder.AddColumn<int>(
                name: "NroDosis",
                table: "VacunasDelPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EstaActivo",
                table: "SeguimientosDeVacunacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Completado",
                table: "PlanesDeVacunacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FueParteDeAdopcion",
                table: "AnimalVacuna",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroDosis",
                table: "VacunasDelPlan");

            migrationBuilder.DropColumn(
                name: "EstaActivo",
                table: "SeguimientosDeVacunacion");

            migrationBuilder.DropColumn(
                name: "Completado",
                table: "PlanesDeVacunacion");

            migrationBuilder.DropColumn(
                name: "FueParteDeAdopcion",
                table: "AnimalVacuna");

            migrationBuilder.RenameColumn(
                name: "FechaDeAplicacion",
                table: "VacunasDelPlan",
                newName: "FechaDeCompletado");

            migrationBuilder.RenameColumn(
                name: "FechaAsignada",
                table: "SeguimientosDeVacunacion",
                newName: "FechaDeAsignacion");

            migrationBuilder.AddColumn<bool>(
                name: "EstaCompleta",
                table: "VacunasDelPlan",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
