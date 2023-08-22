using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_BarrioSeedData : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
