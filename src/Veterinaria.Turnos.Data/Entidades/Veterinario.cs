using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Veterinario
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    
    public string Apellido { get; set; } = null!;

    [StringLength(50)]
    
    public string? Matricula { get; set; }

    [StringLength(50)]
    
    public string Telefono { get; set; } = null!;

    [StringLength(100)]
    
    public string Email { get; set; } = null!;

    [StringLength(100)]
    
    public string? Calle { get; set; }

    public int? Altura { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
