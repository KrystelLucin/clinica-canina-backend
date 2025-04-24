using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("servicio")]
    public class Servicio
    {
        [Key]
        [Column("id_servicio")]
        public int Id { get; set; }

        
        [Column("nombre_servicio")]
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
