using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_SeguimientoDeVacunacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeguimientoDeVacunaciones",
                columns: table => new
                {
                    Id_Solicitud = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false),
                    FechaDeAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PorReprogramar = table.Column<bool>(type: "bit", nullable: false),
                    EstaAplicada = table.Column<bool>(type: "bit", nullable: false),
                    NroDosis = table.Column<byte>(type: "tinyint", nullable: false),
                    NroLote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Veterinaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoDeVacunaciones", x => new { x.Id_Solicitud, x.Id_Vacuna });
                    table.ForeignKey(
                        name: "FK_SeguimientoDeVacunaciones_SolicitudesDeAdopcion_Id_Solicitud",
                        column: x => x.Id_Solicitud,
                        principalTable: "SolicitudesDeAdopcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeguimientoDeVacunaciones_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeguimientoDeVacunaciones_Veterinarias_Id_Veterinaria",
                        column: x => x.Id_Veterinaria,
                        principalTable: "Veterinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoDeVacunaciones_Id_Vacuna",
                table: "SeguimientoDeVacunaciones",
                column: "Id_Vacuna");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoDeVacunaciones_Id_Veterinaria",
                table: "SeguimientoDeVacunaciones",
                column: "Id_Veterinaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeguimientoDeVacunaciones");
        }
    }
}
