using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("CATEGORIASPRODUCTOS")]
    public class CategoriasProcuctos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; } = string.Empty;
    }
}
