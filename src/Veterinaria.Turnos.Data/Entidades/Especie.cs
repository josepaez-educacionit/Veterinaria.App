using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Especie
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
