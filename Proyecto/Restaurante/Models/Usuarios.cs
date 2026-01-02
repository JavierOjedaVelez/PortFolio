using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Restaurante.Models
{

    [Table("USUARIOS")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(510)")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "int")]
        public int IdRol { get; set; }

        [ForeignKey(nameof(IdRol))]
        public Roles Rol { get; set; } = null!;

        public ICollection<HorariosTrabajadorcs> Horario { get; set; } = new List<HorariosTrabajadorcs>();

    }
}
