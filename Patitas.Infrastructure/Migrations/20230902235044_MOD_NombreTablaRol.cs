using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOD_NombreTablaRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_RolesUsuario_Id_RolUsuario",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "RolesUsuario");

            migrationBuilder.RenameColumn(
                name: "Id_RolUsuario",
                table: "Usuarios",
                newName: "Id_Rol");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_RolUsuario",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_Rol");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_Id_Rol",
                table: "Usuarios",
                column: "Id_Rol",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_Id_Rol",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.RenameColumn(
                name: "Id_Rol",
                table: "Usuarios",
                newName: "Id_RolUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_Rol",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_RolUsuario");

            migrationBuilder.CreateTable(
                name: "RolesUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuario", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_RolesUsuario_Id_RolUsuario",
                table: "Usuarios",
                column: "Id_RolUsuario",
                principalTable: "RolesUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
