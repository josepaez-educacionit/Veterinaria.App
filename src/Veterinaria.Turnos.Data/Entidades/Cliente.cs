using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Cliente
{
    [Key]
    public int Id { get; set; }

	[Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name = "Nº Documento")]
	public int NumeroDocumento { get; set; }

	[Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1} caracteres.")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name = "Teléfono")]
    [StringLength(50, ErrorMessage = "La longitud del campo {0} no puede exceder los {1} caracteres.")]
    public string Telefono { get; set; } = null!;

    [StringLength(100)]
    [EmailAddress(ErrorMessage = "El campo {0} no es una dirección de correo válida.")]
    [Display(Name = "Correo Electrónico")]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string? Calle { get; set; }

    public int? Altura { get; set; }

    public virtual ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
}
