using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Mascota
{
    [Key]
    public int Id { get; set; }

	[Required(ErrorMessage = "El campo {0} es obligatorio.")]
	[StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres")]
	public string Nombre { get; set; } = null!;

	[Display(Name = "Cliente")]
	public int ClienteId { get; set; }

	[Display(Name = "Especie")]
	public int EspecieId { get; set; }

	[Display(Name = "Raza")]
	public int RazaId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Cliente Cliente { get; set; } = null!;

    [ForeignKey("EspecieId")]
    public virtual Especie Especie { get; set; } = null!;

    [ForeignKey("RazaId")]
    public virtual Raza Raza { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
