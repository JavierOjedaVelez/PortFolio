using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    [Table("PROMOCIONES")]
    public class Promociones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPromocion { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; } = null!;
        [Column(TypeName = "nvarchar(765)")]
        public string Descripcion { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; } = 0.00M;

        [Column(TypeName = "datetime")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaCaducidad { get; set; }

        [Column(TypeName = "int")]
        public int IdTipo { get; set; }

        [Column(TypeName="bit")]
        public bool Activo { get; set; }

        [ForeignKey(nameof(IdTipo))]
        public TiposPromocion Tipo { get; set; } = null!;

    }
}
