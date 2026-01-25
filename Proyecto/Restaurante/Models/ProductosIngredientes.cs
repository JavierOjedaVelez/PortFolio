using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    [Table("PRODUCTOSINGREDIENTES")]
    public class ProductosIngredientes
    {
        [Column(TypeName = "int")]
        public int IdProducto { get; set; }
        [Column(TypeName = "int")]
        public int IdIngrediente { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cantidad { get; set; } = 0.00M;

        [ForeignKey(nameof(IdProducto))]
        public Productos Productos { get; set; } = null!;

        [ForeignKey(nameof(IdIngrediente))]
        public Ingredientes Ingredientes { get; set; } = null!;
    }
}
