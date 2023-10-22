using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOD_FormularioPreAdopcionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormulariosPreAdopcion_Refugios_Id_Refugio",
                table: "FormulariosPreAdopcion");

            migrationBuilder.DropIndex(
                name: "IX_FormulariosPreAdopcion_Id_Refugio",
                table: "FormulariosPreAdopcion");

            migrationBuilder.RenameColumn(
                name: "Id_Refugio",
                table: "FormulariosPreAdopcion",
                newName: "Id_SolicitudDeAdopcion");

            migrationBuilder.CreateIndex(
                name: "IX_FormulariosPreAdopcion_Id_SolicitudDeAdopcion",
                table: "FormulariosPreAdopcion",
                column: "Id_SolicitudDeAdopcion",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormulariosPreAdopcion_SolicitudesDeAdopcion_Id_SolicitudDeAdopcion",
                table: "FormulariosPreAdopcion",
                column: "Id_SolicitudDeAdopcion",
                principalTable: "SolicitudesDeAdopcion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormulariosPreAdopcion_SolicitudesDeAdopcion_Id_SolicitudDeAdopcion",
                table: "FormulariosPreAdopcion");

            migrationBuilder.DropIndex(
                name: "IX_FormulariosPreAdopcion_Id_SolicitudDeAdopcion",
                table: "FormulariosPreAdopcion");

            migrationBuilder.RenameColumn(
                name: "Id_SolicitudDeAdopcion",
                table: "FormulariosPreAdopcion",
                newName: "Id_Refugio");

            migrationBuilder.CreateIndex(
                name: "IX_FormulariosPreAdopcion_Id_Refugio",
                table: "FormulariosPreAdopcion",
                column: "Id_Refugio");

            migrationBuilder.AddForeignKey(
                name: "FK_FormulariosPreAdopcion_Refugios_Id_Refugio",
                table: "FormulariosPreAdopcion",
                column: "Id_Refugio",
                principalTable: "Refugios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
