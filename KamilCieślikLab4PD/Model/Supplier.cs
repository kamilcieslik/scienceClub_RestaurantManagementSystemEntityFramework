using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Model
{
    public class Supplier:Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Localization { get; set; }
        [Required]
        public int DeliveryTime { get; set; }

        
    }
}
