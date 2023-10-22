using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class FormularioPreAdopcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Adoptante { get; set; }
        public int Id_SolicitudDeAdopcion { get; set; }

        [StringLength(200)]
        public string Motivo { get; set; } = string.Empty;
        public bool TuvoMascota { get; set; }
        public bool TieneMascotas { get; set; }
        
        [StringLength(200)]
        public string? DescripcionMascotas { get; set; }
        public bool ViveSolo { get; set; }
        public bool TieneVeterinariaCerca { get; set; }
        public bool ViveEnCasa { get; set; }
        public bool ViveEnDepartamento { get; set; }
        public byte CantidadDeAmbientes { get; set; }
        public bool TienePatio { get; set; }
        public bool TieneBalcon { get; set; }
        public bool TieneRedEnVentanas { get; set; }
        public bool ConoceLeyDeMaltratoAnimal { get; set; }

        [StringLength(50)]
        public string FrecuenciaAnimalSolo { get; set; } = string.Empty;
        public bool TieneConocidosEnCasoDeEmergencia { get; set; }
        public bool TieneSalarioAcordeAGastos { get; set; }
        public bool TieneConocidosQueLoAconsejen { get; set; }

        [ForeignKey(nameof(Id_Adoptante))]
        public Adoptante Adoptante { get; set; } = null!;

        [ForeignKey(nameof(Id_SolicitudDeAdopcion))]
        public SolicitudDeAdopcion SolicitudDeAdopcion { get; set; } = null!;
    }
}
