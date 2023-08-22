using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DEL_COL_RequiereDosisDeRefuerzo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiereDosisDeRefuerzo",
                table: "Vacunas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequiereDosisDeRefuerzo",
                table: "Vacunas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
