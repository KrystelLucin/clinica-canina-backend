using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("dueno")]
    public class Dueno
    {
        [Key]
        [Column("numero_identificacion")]
        [MaxLength(10)]
        public string Id { get; set; } = string.Empty;

        [Column("nombre_completo")]
        [MaxLength(100)]
        [Required]
        public string NombreCompleto { get; set; } = string.Empty;

        [Column("direccion")]
        [MaxLength(100)]
        [Required]
        public string Direccion { get; set; } = string.Empty;
    
        [Column("telefono")]
        [MaxLength(10)]
        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Column("correo")]
        [MaxLength(100)]
        public string? Correo { get; set; }

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
