using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("INGREDIENTES")]
    public class Ingredientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIngrediente { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(765)")]
        public string Descripcion { get; set; } = string.Empty;


        //Ha momento de hacer esto, no existe el modelo de proveedor
        [Required]
        [Column(TypeName = "int")]
        public int IdProveedor { get; set; }
    }
}
