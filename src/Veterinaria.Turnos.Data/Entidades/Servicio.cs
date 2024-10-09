using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Servicio
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Tipo de Servicio")]
    public int TipoServicioId { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
	[StringLength(100, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
	public string Nombre { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? Precio { get; set; }

    [Display(Name = "Duración en minutos")]
    public short? DuracionMinutos { get; set; }

    [ForeignKey("TipoServicioId")]
    public virtual TipoServicio TipoServicio { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
