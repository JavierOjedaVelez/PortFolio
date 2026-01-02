using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("RESTAURANTES")]
    public class Restaurantes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRestaurante { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(510)")]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public int CapacidadTotal { get; set; }

        public ICollection<Mesas> mesas { get; set; } = new List<Mesas>();

    }
}
