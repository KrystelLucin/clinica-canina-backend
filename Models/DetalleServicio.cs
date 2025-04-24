using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("detalle_servicio")]
    public class DetalleServicio
    {
        [Key]
        [Column("id_detalle")]
        public int Id { get; set; }

        [Required]
        [Column("id_cita")]
        public int IdCita { get; set; }

        [Required]
        [Column("id_servicio")]
        public int IdServicio { get; set; }

        [Column("id_tipo_medicamento")]
        public int? IdTipoMedicamento { get; set; }

        [Column("observaciones")]
        public string? Observaciones { get; set; }

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
