using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("tipo_medicamento")]
    public class TipoMedicamento
    {
        [Key]
        [Column("id_tipo_medicamento")]
        public int Id { get; set; }

        
        [Column("nombre_tipo")]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Column("descripcion")]
        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
