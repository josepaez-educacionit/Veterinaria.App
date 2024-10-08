using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Turnos.Data.Entidades;

public partial class Raza
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    
    public string Nombre { get; set; } = null!;

    public int EspecieId { get; set; }

    [ForeignKey("EspecieId")]
    public virtual Especie Especie { get; set; } = null!;

    public virtual ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
}
