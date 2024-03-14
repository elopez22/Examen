using System.ComponentModel.DataAnnotations;

namespace App.Front.Examen.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public int Rama { get; set; }
    }
}
