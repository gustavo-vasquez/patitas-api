using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;

namespace Patitas.Infrastructure
{
    public class PatitasContext : DbContext
    {
        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<RolUsuario> RolesUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Veterinaria> Veterinarias { get; set; }
        public DbSet<FormularioPreAdopcion> FormulariosPreAdopcion { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<DetalleEstrella> DetalleEstrellas { get; set; }
        public DbSet<VeterinariaAsignadaARefugio> VeterinariasAsignadasARefugios { get; set; }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<ModeracionDePublicacion> ModeracionDePublicaciones { get; set; }
        public DbSet<CausaDeDenuncia> CausasDeDenuncia { get; set; }
        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<SolicitudDeAdopcion> SolicitudesDeAdopcion { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        //public DbSet<AdoptanteCancelaAdopcion> AdoptantesQueCancelaronAdopciones { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<AnimalVacuna> AnimalVacuna { get; set; }
        public DbSet<SeguimientoDeVacunacion> SeguimientoDeVacunaciones { get; set; }
        public DbSet<EspecieVacuna> EspecieVacuna { get; set; }

        public PatitasContext(DbContextOptions<PatitasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Barrio>().HasData(
                new Barrio() { Id = 1, Nombre = "Congreso" },
                new Barrio() { Id = 2, Nombre = "Palermo" },
                new Barrio() { Id = 3, Nombre = "Puerto Madero" },
                new Barrio() { Id = 4, Nombre = "Recoleta" }
            );

            modelBuilder.Entity<RolUsuario>().HasData(
                new RolUsuario() { Id = 1, Nombre = "Administrador" },
                new RolUsuario() { Id = 2, Nombre = "Adoptante" },
                new RolUsuario() { Id = 3, Nombre = "Refugio" },
                new RolUsuario() { Id = 4, Nombre = "Veterinaria" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario() { Id = 1, NombreUsuario = "Cosme_Fulanito", Email = "cosme.fulanito@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 4, Id_RolUsuario = 2 },
                new Usuario() { Id = 2, NombreUsuario = "Administrador", Email = "admin.patitas@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 3, Id_RolUsuario = 1 },
                new Usuario() { Id = 3, NombreUsuario = "Refugio.San.Pedro", Email = "refugio_sanpedro@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 2, Id_RolUsuario = 3 },
                new Usuario() { Id = 4, NombreUsuario = "Picaduras", Email = "picaduras_oficial@gmail.com", Password = "asd123", FechaCreacion = DateTime.Now, Id_Barrio = 1, Id_RolUsuario = 4 }
            );

            modelBuilder.Entity<Adoptante>().HasData(
                new Adoptante() { Id = 1, Nombre = "Cosme", Apellido = "Fulanito" }
            );

            modelBuilder.Entity<Administrador>().HasData(
                new Administrador() { Id = 2, EsFundador = true }
            );

            modelBuilder.Entity<Refugio>().HasData(
                new Refugio() { Id = 3, Nombre = "San Pedro", RazonSocial = "Refugio San Pedro S.A.", NombreResponsable = "Homero", ApellidoResponsable = "Simpson", HorarioApertura = "09", HorarioCierre = "14" }
            );

            modelBuilder.Entity<Veterinaria>().HasData(
                new Veterinaria() { Id = 4, Nombre = "Picaduras", RazonSocial = "Picaduras S.R.L.", Especialidades = "Vacunación, Cirugía, Ecografía, Peluquería", FechaFundacion = DateTime.Parse("2012-10-28"), HorarioApertura = "10", HorarioCierre = "20" }
            );

            ////////////////////////////////////////////////////////////////

            modelBuilder.Entity<Usuario>()
                .HasOne(e => e.Administrador)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Administrador>(e => e.Id) // Establezco la relación 1 a 1 compartiendo la clave con la tabla Usuarios
                .IsRequired();

            modelBuilder.Entity<Administrador>()
                .HasIndex(e => e.Id)
                .IsUnique(); // El campo id de Administrador debe ser único

            modelBuilder.Entity<Usuario>()
                .HasOne(e => e.Adoptante)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Adoptante>(e => e.Id)
                .IsRequired();

            modelBuilder.Entity<Adoptante>()
                .HasIndex(e => e.Id)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasOne(e => e.Refugio)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Refugio>(e => e.Id)
                .IsRequired();

            modelBuilder.Entity<Refugio>()
                .HasIndex(e => e.Id)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasOne(e => e.Veterinaria)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Veterinaria>(e => e.Id)
                .IsRequired();

            modelBuilder.Entity<Veterinaria>()
                .HasIndex(e => e.Id)
                .IsUnique();

            modelBuilder.Entity<FormularioPreAdopcion>()
                .HasIndex(e => e.Id_Adoptante)
                .IsUnique();

            modelBuilder.Entity<Comentario>()
                .HasOne(r => r.Refugio)
                .WithMany(c => c.Comentarios)
                .HasForeignKey(c => c.Id_Refugio)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Altura)
                .HasColumnType("decimal(2, 2)");

            // Relaciones N a N
            modelBuilder.Entity<Veterinaria>()
                .HasMany(r => r.Refugios)
                .WithMany(v => v.Veterinarias)
                .UsingEntity<VeterinariaAsignadaARefugio>(
                    l => l.HasOne<Refugio>().WithMany().HasForeignKey(r => r.Id_Refugio).OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne<Veterinaria>().WithMany().HasForeignKey(v => v.Id_Veterinaria).OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder.Entity<Administrador>()
                .HasMany(e => e.Publicaciones)
                .WithMany(e => e.Administradores)
                .UsingEntity<ModeracionDePublicacion>(
                    l => l.HasOne<Publicacion>().WithMany().HasForeignKey(p => p.Id_Publicacion).OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne<Administrador>().WithMany().HasForeignKey(a => a.Id_Administrador)
                );

            /*modelBuilder.Entity<Adoptante>()
                .HasMany(a => a.SolicitudesDeAdopcionCanceladas)
                .WithMany(sc => sc.AdoptantesQueCancelaron)
                .UsingEntity<AdoptanteCancelaAdopcion>(
                l => l.HasOne<SolicitudDeAdopcion>().WithMany().HasForeignKey(aca => aca.Id_SolicitudAdopcion),
                r => r.HasOne<Adoptante>().WithMany().HasForeignKey(aca => aca.Id_Adoptante));*/

            modelBuilder.Entity<Animal>()
                .HasMany(a => a.Vacunas)
                .WithMany(v => v.Animales)
                .UsingEntity<AnimalVacuna>(
                    l => l.HasOne<Vacuna>().WithMany().HasForeignKey(av => av.Id_Vacuna),
                    r => r.HasOne<Animal>().WithMany().HasForeignKey(av => av.Id_Animal)
                );

            modelBuilder.Entity<SolicitudDeAdopcion>()
                .HasMany(sa => sa.Vacunas)
                .WithMany(v => v.SolicitudesDeAdopcion)
                .UsingEntity<SeguimientoDeVacunacion>(
                    l => l.HasOne<Vacuna>().WithMany().HasForeignKey(seg => seg.Id_Vacuna),
                    r => r.HasOne<SolicitudDeAdopcion>().WithMany().HasForeignKey(seg => seg.Id_Solicitud)
                );

            modelBuilder.Entity<Especie>()
                .HasMany(r => r.Vacunas)
                .WithMany(v => v.Especies)
                .UsingEntity<EspecieVacuna>(
                    l => l.HasOne<Vacuna>().WithMany().HasForeignKey(rv => rv.Id_Vacuna),
                    r => r.HasOne<Especie>().WithMany().HasForeignKey(rv => rv.Id_Especie)
                );

            ///////////////////////////////////////////////////////////

            // Correcciones de 'cycles or multiple cascade paths'

            modelBuilder.Entity<Denuncia>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Denuncias)
                .HasForeignKey(u => u.Id_Usuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudDeAdopcion>()
                .HasOne(s => s.Animal)
                .WithMany(a => a.SolicitudesDeAdopcion)
                .HasForeignKey(a => a.Id_Animal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudDeAdopcion>()
                .HasOne(s => s.Refugio)
                .WithMany(r => r.SolicitudesDeAdopcion)
                .HasForeignKey(r => r.Id_Refugio)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Refugio)
                .WithMany(r => r.Turnos)
                .HasForeignKey(r => r.Id_Refugio)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.SolicitudDeAdopcion)
                .WithMany(s => s.Turnos)
                .HasForeignKey(s => s.Id_SolicitudDeAdopcion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SeguimientoDeVacunacion>()
                .HasOne(sv => sv.Veterinaria)
                .WithMany(v => v.SeguimientoDeVacunaciones)
                .HasForeignKey(sv => sv.Id_Veterinaria)
                .OnDelete(DeleteBehavior.Restrict);

            //////////////////////////////////////////////////////////

            modelBuilder.Entity<SolicitudDeAdopcion>()
                .HasOne(sa => sa.Adoptante)
                .WithMany(a => a.SolicitudesDeAdopcion)
                .HasForeignKey(a => a.Id_Adoptante);
        }
    }
}
