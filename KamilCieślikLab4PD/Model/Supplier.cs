using System.ComponentModel.DataAnnotations;

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
