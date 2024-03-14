using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAcces.Entities
{
  
    public class Ramo
    {
        [Key]
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Descripcion { get; set; }
    }
}
