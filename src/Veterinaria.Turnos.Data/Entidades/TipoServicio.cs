using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

[Table("TiposServicio")]
public partial class TipoServicio
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
