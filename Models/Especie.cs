using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("especie")]
    public class Especie
    {
        [Key]
        [Column("id_especie")]
        public int Id { get; set; }

        [Column("nombre")]
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
