using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("mascota")]
    public class Mascota
    {
        [Key]
        [Column("id_mascota")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column("id_dueno")]
        [MaxLength(10)]
        public string IdDueno { get; set; } = string.Empty;

        [Column("id_especie")]
        public int? IdEspecie { get; set; }

        [Column("id_raza")]
        public int? IdRaza { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("id_sexo")]
        public int? IdSexo { get; set; }

        [Column("color")]
        [MaxLength(30)]
        public string? Color { get; set; }

        [Column("peso")]
        public decimal? Peso { get; set; }

        [Column("informacion_adicional")]
        public string? InformacionAdicional { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public int? CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [Column("deleted_by")]
        public int? DeletedBy { get; set; }
    }
}
