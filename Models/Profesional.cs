using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("profesional")]
    public class Profesional
    {
        [Key]
        [Column("id_profesional")]
        public int Id { get; set; }

        [Required]
        [Column("nombre_completo")]
        [MaxLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

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
