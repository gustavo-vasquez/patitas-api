using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patitas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TodasLasEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CausasDeDenuncia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausasDeDenuncia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleEstrellas",
                columns: table => new
                {
                    NroEstrella = table.Column<byte>(type: "tinyint", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleEstrellas", x => x.NroEstrella);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadDeDosis = table.Column<int>(type: "int", nullable: false),
                    EdadIndicada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Especie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Razas_Especies_Id_Especie",
                        column: x => x.Id_Especie,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotoDePerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Id_Barrio = table.Column<int>(type: "int", nullable: false),
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Barrios_Id_Barrio",
                        column: x => x.Id_Barrio,
                        principalTable: "Barrios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_Id_Rol",
                        column: x => x.Id_Rol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspecieVacuna",
                columns: table => new
                {
                    Id_Especie = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieVacuna", x => new { x.Id_Especie, x.Id_Vacuna });
                    table.ForeignKey(
                        name: "FK_EspecieVacuna_Especies_Id_Especie",
                        column: x => x.Id_Especie,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecieVacuna_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EsFundador = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoptantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DNI = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptantes_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditadoPorAdministrador = table.Column<bool>(type: "bit", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Id_Tema = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    RespondeA_IdPublicacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Publicaciones_RespondeA_IdPublicacion",
                        column: x => x.RespondeA_IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Publicaciones_Temas_Id_Tema",
                        column: x => x.Id_Tema,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refugios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreResponsable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoResponsable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SitioWeb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiasDeAtencion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HorarioApertura = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    HorarioCierre = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refugios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refugios_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidades = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaFundacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelefonoAlternativo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiasDeAtencion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HorarioApertura = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    HorarioCierre = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinarias_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormulariosPreAdopcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TuvoMascota = table.Column<bool>(type: "bit", nullable: false),
                    ViveSolo = table.Column<bool>(type: "bit", nullable: false),
                    ViveEnCasa = table.Column<bool>(type: "bit", nullable: false),
                    ViveEnDepartamento = table.Column<bool>(type: "bit", nullable: false),
                    CantidadDeAmbientes = table.Column<byte>(type: "tinyint", nullable: false),
                    TienePatio = table.Column<bool>(type: "bit", nullable: false),
                    TieneBalcon = table.Column<bool>(type: "bit", nullable: false),
                    TieneRedEnVentanas = table.Column<bool>(type: "bit", nullable: false),
                    TieneVeterinariaCerca = table.Column<bool>(type: "bit", nullable: false),
                    TieneMascotas = table.Column<bool>(type: "bit", nullable: false),
                    DescripcionMascotas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConoceLeyDeMaltratoAnimal = table.Column<bool>(type: "bit", nullable: false),
                    FrecuenciaAnimalSolo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TieneConocidosEnCasoDeEmergencia = table.Column<bool>(type: "bit", nullable: false),
                    TieneSalarioAcordeAGastos = table.Column<bool>(type: "bit", nullable: false),
                    TieneConocidosQueLoAconsejen = table.Column<bool>(type: "bit", nullable: false),
                    Id_Adoptante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulariosPreAdopcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulariosPreAdopcion_Adoptantes_Id_Adoptante",
                        column: x => x.Id_Adoptante,
                        principalTable: "Adoptantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescripcionAdicional = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Id_CausaDeDenuncia = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Id_Publicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denuncias_CausasDeDenuncia_Id_CausaDeDenuncia",
                        column: x => x.Id_CausaDeDenuncia,
                        principalTable: "CausasDeDenuncia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Publicaciones_Id_Publicacion",
                        column: x => x.Id_Publicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModeracionDePublicaciones",
                columns: table => new
                {
                    Id_Publicacion = table.Column<int>(type: "int", nullable: false),
                    Id_Administrador = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FueEditado = table.Column<bool>(type: "bit", nullable: false),
                    FueEliminado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeracionDePublicaciones", x => new { x.Id_Publicacion, x.Id_Administrador });
                    table.ForeignKey(
                        name: "FK_ModeracionDePublicaciones_Administradores_Id_Administrador",
                        column: x => x.Id_Administrador,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeracionDePublicaciones_Publicaciones_Id_Publicacion",
                        column: x => x.Id_Publicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nacimiento = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacionPrevia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    Esterilizado = table.Column<bool>(type: "bit", nullable: false),
                    Desparasitado = table.Column<bool>(type: "bit", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescripcionAdicional = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EstaAdoptado = table.Column<bool>(type: "bit", nullable: false),
                    FechaAdopcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_Raza = table.Column<int>(type: "int", nullable: false),
                    Id_Refugio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animales_Razas_Id_Raza",
                        column: x => x.Id_Raza,
                        principalTable: "Razas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animales_Refugios_Id_Refugio",
                        column: x => x.Id_Refugio,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaEdicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nro_Estrellas = table.Column<byte>(type: "tinyint", nullable: false),
                    Id_Refugio = table.Column<int>(type: "int", nullable: false),
                    Id_Adoptante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Adoptantes_Id_Adoptante",
                        column: x => x.Id_Adoptante,
                        principalTable: "Adoptantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_DetalleEstrellas_Nro_Estrellas",
                        column: x => x.Nro_Estrellas,
                        principalTable: "DetalleEstrellas",
                        principalColumn: "NroEstrella",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Refugios_Id_Refugio",
                        column: x => x.Id_Refugio,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeterinariasAsignadasARefugios",
                columns: table => new
                {
                    Id_Veterinaria = table.Column<int>(type: "int", nullable: false),
                    Id_Refugio = table.Column<int>(type: "int", nullable: false),
                    FechaDeAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeterinariasAsignadasARefugios", x => new { x.Id_Veterinaria, x.Id_Refugio });
                    table.ForeignKey(
                        name: "FK_VeterinariasAsignadasARefugios_Refugios_Id_Refugio",
                        column: x => x.Id_Refugio,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeterinariasAsignadasARefugios_Veterinarias_Id_Veterinaria",
                        column: x => x.Id_Veterinaria,
                        principalTable: "Veterinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalVacuna",
                columns: table => new
                {
                    Id_Animal = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false),
                    NroDosisAplicada = table.Column<int>(type: "int", nullable: false),
                    FechaDeAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FueParteDeAdopcion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalVacuna", x => new { x.Id_Animal, x.Id_Vacuna });
                    table.ForeignKey(
                        name: "FK_AnimalVacuna_Animales_Id_Animal",
                        column: x => x.Id_Animal,
                        principalTable: "Animales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalVacuna_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesDeAdopcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aprobada = table.Column<bool>(type: "bit", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Id_Adoptante = table.Column<int>(type: "int", nullable: false),
                    Id_Animal = table.Column<int>(type: "int", nullable: false),
                    Id_Refugio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesDeAdopcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesDeAdopcion_Adoptantes_Id_Adoptante",
                        column: x => x.Id_Adoptante,
                        principalTable: "Adoptantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesDeAdopcion_Animales_Id_Animal",
                        column: x => x.Id_Animal,
                        principalTable: "Animales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudesDeAdopcion_Refugios_Id_Refugio",
                        column: x => x.Id_Refugio,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "PlanesDeVacunacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_SolicitudDeAdopcion = table.Column<int>(type: "int", nullable: false),
                    Id_Veterinaria = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    Completado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCompletado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesDeVacunacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanesDeVacunacion_SolicitudesDeAdopcion_Id_SolicitudDeAdopcion",
                        column: x => x.Id_SolicitudDeAdopcion,
                        principalTable: "SolicitudesDeAdopcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanesDeVacunacion_Veterinarias_Id_Veterinaria",
                        column: x => x.Id_Veterinaria,
                        principalTable: "Veterinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientosDeVacunacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAsignada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaAplicada = table.Column<bool>(type: "bit", nullable: false),
                    NroDosis = table.Column<byte>(type: "tinyint", nullable: false),
                    NroLote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PorReprogramar = table.Column<bool>(type: "bit", nullable: false),
                    MotivoDeReprogramacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    Asistio = table.Column<bool>(type: "bit", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    PorReprogramar = table.Column<bool>(type: "bit", nullable: false),
                    MotivoDeReprogramacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Id_SolicitudDeAdopcion = table.Column<int>(type: "int", nullable: false),
                    Id_Adoptante = table.Column<int>(type: "int", nullable: false),
                    Id_Refugio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Adoptantes_Id_Adoptante",
                        column: x => x.Id_Adoptante,
                        principalTable: "Adoptantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_Refugios_Id_Refugio",
                        column: x => x.Id_Refugio,
                        principalTable: "Refugios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_SolicitudesDeAdopcion_Id_SolicitudDeAdopcion",
                        column: x => x.Id_SolicitudDeAdopcion,
                        principalTable: "SolicitudesDeAdopcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacunasDelPlan",
                columns: table => new
                {
                    Id_PlanDeVacunacion = table.Column<int>(type: "int", nullable: false),
                    Id_Vacuna = table.Column<int>(type: "int", nullable: false),
                    NroDosis = table.Column<int>(type: "int", nullable: false),
                    FechaDeAplicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacunasDelPlan", x => new { x.Id_PlanDeVacunacion, x.Id_Vacuna });
                    table.ForeignKey(
                        name: "FK_VacunasDelPlan_PlanesDeVacunacion_Id_PlanDeVacunacion",
                        column: x => x.Id_PlanDeVacunacion,
                        principalTable: "PlanesDeVacunacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacunasDelPlan_Vacunas_Id_Vacuna",
                        column: x => x.Id_Vacuna,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Id",
                table: "Administradores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adoptantes_Id",
                table: "Adoptantes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animales_Id_Raza",
                table: "Animales",
                column: "Id_Raza");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_Id_Refugio",
                table: "Animales",
                column: "Id_Refugio");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalVacuna_Id_Vacuna",
                table: "AnimalVacuna",
                column: "Id_Vacuna");

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionesDeAdopcion_Id_Solicitud",
                table: "CancelacionesDeAdopcion",
                column: "Id_Solicitud");

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionesDeAdopcion_Id_Usuario",
                table: "CancelacionesDeAdopcion",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Id_Adoptante",
                table: "Comentarios",
                column: "Id_Adoptante");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Id_Refugio",
                table: "Comentarios",
                column: "Id_Refugio");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Nro_Estrellas",
                table: "Comentarios",
                column: "Nro_Estrellas");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_Id_CausaDeDenuncia",
                table: "Denuncias",
                column: "Id_CausaDeDenuncia");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_Id_Publicacion",
                table: "Denuncias",
                column: "Id_Publicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_Id_Usuario",
                table: "Denuncias",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_EspecieVacuna_Id_Vacuna",
                table: "EspecieVacuna",
                column: "Id_Vacuna");

            migrationBuilder.CreateIndex(
                name: "IX_FormulariosPreAdopcion_Id_Adoptante",
                table: "FormulariosPreAdopcion",
                column: "Id_Adoptante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModeracionDePublicaciones_Id_Administrador",
                table: "ModeracionDePublicaciones",
                column: "Id_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeVacunacion_Id_SolicitudDeAdopcion",
                table: "PlanesDeVacunacion",
                column: "Id_SolicitudDeAdopcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeVacunacion_Id_Veterinaria",
                table: "PlanesDeVacunacion",
                column: "Id_Veterinaria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_Id_Tema",
                table: "Publicaciones",
                column: "Id_Tema");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_Id_Usuario",
                table: "Publicaciones",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_RespondeA_IdPublicacion",
                table: "Publicaciones",
                column: "RespondeA_IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_Id_Especie",
                table: "Razas",
                column: "Id_Especie");

            migrationBuilder.CreateIndex(
                name: "IX_Refugios_Id",
                table: "Refugios",
                column: "Id",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesDeAdopcion_Id_Adoptante",
                table: "SolicitudesDeAdopcion",
                column: "Id_Adoptante");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesDeAdopcion_Id_Animal",
                table: "SolicitudesDeAdopcion",
                column: "Id_Animal");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesDeAdopcion_Id_Refugio",
                table: "SolicitudesDeAdopcion",
                column: "Id_Refugio");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_Id_Adoptante",
                table: "Turnos",
                column: "Id_Adoptante");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_Id_Refugio",
                table: "Turnos",
                column: "Id_Refugio");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_Id_SolicitudDeAdopcion",
                table: "Turnos",
                column: "Id_SolicitudDeAdopcion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_Barrio",
                table: "Usuarios",
                column: "Id_Barrio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_Rol",
                table: "Usuarios",
                column: "Id_Rol");

            migrationBuilder.CreateIndex(
                name: "IX_VacunasDelPlan_Id_Vacuna",
                table: "VacunasDelPlan",
                column: "Id_Vacuna");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarias_Id",
                table: "Veterinarias",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VeterinariasAsignadasARefugios_Id_Refugio",
                table: "VeterinariasAsignadasARefugios",
                column: "Id_Refugio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalVacuna");

            migrationBuilder.DropTable(
                name: "CancelacionesDeAdopcion");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "EspecieVacuna");

            migrationBuilder.DropTable(
                name: "FormulariosPreAdopcion");

            migrationBuilder.DropTable(
                name: "ModeracionDePublicaciones");

            migrationBuilder.DropTable(
                name: "SeguimientosDeVacunacion");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "VacunasDelPlan");

            migrationBuilder.DropTable(
                name: "VeterinariasAsignadasARefugios");

            migrationBuilder.DropTable(
                name: "DetalleEstrellas");

            migrationBuilder.DropTable(
                name: "CausasDeDenuncia");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "PlanesDeVacunacion");

            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "SolicitudesDeAdopcion");

            migrationBuilder.DropTable(
                name: "Veterinarias");

            migrationBuilder.DropTable(
                name: "Adoptantes");

            migrationBuilder.DropTable(
                name: "Animales");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Refugios");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Barrios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
