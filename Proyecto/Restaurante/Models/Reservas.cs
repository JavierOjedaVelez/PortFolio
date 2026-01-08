using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Humanizer;
using System;

namespace Restaurante.Models
{
    [Table("RESERVAS")]
    public class Reservas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FechaReserva { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int IdUsuario { get; set;}


        [Required]
        [Column(TypeName = "int")]
        public int IdMesa { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int IdEstado { get; set; }



        [ForeignKey(nameof(IdUsuario))]
        public Usuarios usuario { get; set; } = null!;

        [ForeignKey(nameof(IdMesa))]
        public Mesas? mesas { get; set; } = null!;

        [ForeignKey(nameof(IdEstado))]
        public EstadoPedido estados { get; set; } = null!;

    }
}
