using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOD_VacunaDelPlanOnePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VacunasDelPlan",
                table: "VacunasDelPlan");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VacunasDelPlan",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacunasDelPlan",
                table: "VacunasDelPlan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VacunasDelPlan_Id_PlanDeVacunacion",
                table: "VacunasDelPlan",
                column: "Id_PlanDeVacunacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VacunasDelPlan",
                table: "VacunasDelPlan");

            migrationBuilder.DropIndex(
                name: "IX_VacunasDelPlan_Id_PlanDeVacunacion",
                table: "VacunasDelPlan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VacunasDelPlan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacunasDelPlan",
                table: "VacunasDelPlan",
                columns: new[] { "Id_PlanDeVacunacion", "Id_Vacuna" });
        }
    }
}
