using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("PRODUCTOS")]
    public class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(765)")]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; } = 0.00M;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string ImagenURL { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public int IdCategoriaProducto {  get; set; }


        //Todavia no existe el modelo
        [Required]
        [Column(TypeName = "int")]
        public int IdPromocion { get; set; }

        [ForeignKey(nameof(IdCategoriaProducto))]
        public CategoriasProcuctos Categorias { get; set; } = null!;
    }
}
