using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("MESAS")]
    public class Mesas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMesa { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Numero { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Capacidad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string CodQR { get; set; } = string.Empty;


        [Required]
        [Column(TypeName = "int")]
        public int IdRestaurante { get; set; }


        [ForeignKey(nameof(IdRestaurante))]
        public Restaurantes Restaurante { get; set; } = null!;
    }
}
