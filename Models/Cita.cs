using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("cita")]
    public class Cita
    {
        [Key]
        [Column("id_cita")]
        public int Id { get; set; }

        [Required]
        [Column("id_mascota")]
        public int IdMascota { get; set; }

        [Required]
        [Column("fecha_hora")]
        public DateTime FechaHora { get; set; }

        [Column("id_profesional")]
        public int? IdProfesional { get; set; }

        [Column("id_servicio")]
        public int? IdServicio { get; set; }

        [Column("motivo")]
        public string? Motivo { get; set; }

        [Required]
        [Column("estado")]
        [MaxLength(20)]
        public string Estado { get; set; } = "Pendiente";

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
