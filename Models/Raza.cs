using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaCanina.API.Models
{
    [Table("raza")]
    public class Raza
    {
        [Key]
        [Column("id_raza")]
        public int Id { get; set; }

        [Column("id_especie")]
        public int IdEspecie { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
