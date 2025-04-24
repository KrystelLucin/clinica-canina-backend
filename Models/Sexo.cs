using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("sexo")]
    public class Sexo
    {
        [Key]
        [Column("id_sexo")]
        public int Id { get; set; }

        [Column("descripcion")]
        [MaxLength(20)]
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
