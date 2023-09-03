using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_SeguimientosDeVacunacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeguimientosDeVacunacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDeAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PorReprogramar = table.Column<bool>(type: "bit", nullable: false),
                    EstaAplicada = table.Column<bool>(type: "bit", nullable: false),
                    NroDosis = table.Column<byte>(type: "tinyint", nullable: false),
                    NroLote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Id_SolicitudDeAdopcion = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false),
                    Id_Veterinaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientosDeVacunacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeguimientosDeVacunacion_SolicitudesDeAdopcion_Id_SolicitudDeAdopcion",
                        column: x => x.Id_SolicitudDeAdopcion,
                        principalTable: "SolicitudesDeAdopcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeguimientosDeVacunacion_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeguimientosDeVacunacion_Veterinarias_Id_Veterinaria",
                        column: x => x.Id_Veterinaria,
                        principalTable: "Veterinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientosDeVacunacion_Id_SolicitudDeAdopcion",
                table: "SeguimientosDeVacunacion",
                column: "Id_SolicitudDeAdopcion");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientosDeVacunacion_Id_Vacuna",
                table: "SeguimientosDeVacunacion",
                column: "Id_Vacuna");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientosDeVacunacion_Id_Veterinaria",
                table: "SeguimientosDeVacunacion",
                column: "Id_Veterinaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeguimientosDeVacunacion");
        }
    }
}
