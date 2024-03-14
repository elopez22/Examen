using System.ComponentModel.DataAnnotations;

namespace App.Front.Examen.Models
{
    public class Ramo
    {
        [Key]
        public int Id { get; set; }
        public string? Pais { get; set; }
        public string? Descripcion { get; set; }
    }
}
