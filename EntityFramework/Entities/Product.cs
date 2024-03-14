using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAcces.Entities
{

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public int Rama { get; set; }

    }
}
