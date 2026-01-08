using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("DETALLESPEDIDOS")]
    public class DetallesPedidos
    {
        [Required]
        [Column(TypeName = "int")]
        public int IdPedido { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int IdProducto { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Cantidad {  get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; } = 0.00M;
    }
}
