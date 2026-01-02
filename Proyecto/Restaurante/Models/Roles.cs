using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Restaurante.Models
{

    [Table("ROLES")]
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string nombre { get; set; } = string.Empty;

        public ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
    }
}
