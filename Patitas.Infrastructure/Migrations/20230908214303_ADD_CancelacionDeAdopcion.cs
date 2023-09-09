using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_CancelacionDeAdopcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancelacionesDeAdopcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaDeCancelacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Solicitud = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelacionesDeAdopcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancelacionesDeAdopcion_SolicitudesDeAdopcion_Id_Solicitud",
                        column: x => x.Id_Solicitud,
                        principalTable: "SolicitudesDeAdopcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancelacionesDeAdopcion_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionesDeAdopcion_Id_Solicitud",
                table: "CancelacionesDeAdopcion",
                column: "Id_Solicitud");

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionesDeAdopcion_Id_Usuario",
                table: "CancelacionesDeAdopcion",
                column: "Id_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelacionesDeAdopcion");
        }
    }
}
