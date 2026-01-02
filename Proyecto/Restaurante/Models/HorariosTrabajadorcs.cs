using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    [Table("HORARIOSTRABAJADOR")]
    public class HorariosTrabajadorcs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int diaSemana { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan horaentrada { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan horaSalida { get; set; }


        [Required]
        [Column(TypeName = "int")]
        public int IdUsuario { get; set; }


        [ForeignKey(nameof(IdUsuario))]
        public Usuarios usuario { get; set; } = null!;
    }
}
