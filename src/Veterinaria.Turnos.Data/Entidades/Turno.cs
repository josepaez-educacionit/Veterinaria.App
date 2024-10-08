using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Turno
{
    [Key]
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public int EstadoTurnoId { get; set; }

    public int? VeterinarioId { get; set; }

    public int? MascotaId { get; set; }

    public int? ServicioId { get; set; }

    [Column(TypeName = "text")]
    public string? Observacion { get; set; }

    [ForeignKey("EstadoTurnoId")]
    public virtual EstadoTurno EstadoTurno { get; set; } = null!;

    [ForeignKey("MascotaId")]
    public virtual Mascota? Mascota { get; set; }

    [ForeignKey("ServicioId")]
    public virtual Servicio? Servicio { get; set; }

    [ForeignKey("VeterinarioId")]
    public virtual Veterinario? Veterinario { get; set; }
}
