using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

[Table("EstadosTurno")]
public partial class EstadoTurno
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
