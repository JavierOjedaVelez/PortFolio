using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("PEDIDOS")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal total {  get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int IdUsuario {  get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int? IdMesa { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int IdEstado { get; set; }



        [ForeignKey(nameof(IdUsuario))]
        public Usuarios usuario { get; set; } = null!;

        [ForeignKey(nameof(IdMesa))]
        public Mesas? mesas { get; set; } = null;

        [ForeignKey(nameof(IdEstado))]
        public EstadoPedido estados { get; set; } = null!;
    }
}
