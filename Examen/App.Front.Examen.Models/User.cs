using System.ComponentModel.DataAnnotations;

namespace App.Front.Examen.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Pws { get; set; }
        public string? Pais { get; set; }
    }
}
