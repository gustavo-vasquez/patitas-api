using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_ColumnaPesoAAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Animales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Animales");
        }
    }
}
