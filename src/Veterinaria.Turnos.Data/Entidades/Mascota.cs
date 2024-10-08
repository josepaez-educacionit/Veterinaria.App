using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Mascota
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    
    public string Nombre { get; set; } = null!;

    public int ClienteId { get; set; }

    public int EspecieId { get; set; }

    public int RazaId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Cliente Cliente { get; set; } = null!;

    [ForeignKey("EspecieId")]
    public virtual Especie Especie { get; set; } = null!;

    [ForeignKey("RazaId")]
    public virtual Raza Raza { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
