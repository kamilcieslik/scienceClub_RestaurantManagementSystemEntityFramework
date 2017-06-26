using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Model
{
    public class Supply:Entity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string OrderedProduct { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int ProviderID { get; set; }

    }
}
