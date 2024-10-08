using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Servicio
{
    [Key]
    public int Id { get; set; }

    public int TipoServicioId { get; set; }

    [StringLength(100)]
    
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? Precio { get; set; }

    public short? DuracionMinutos { get; set; }

    [ForeignKey("TipoServicioId")]
    public virtual TipoServicio TipoServicio { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
