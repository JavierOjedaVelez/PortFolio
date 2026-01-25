using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    [Table("TIPOSPROMOCIONES")]
    public class TiposPromocion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string nombre { get; set; } = null!; 

    }
}
