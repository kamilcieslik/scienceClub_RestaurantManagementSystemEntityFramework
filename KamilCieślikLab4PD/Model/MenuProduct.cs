using System.ComponentModel.DataAnnotations;

namespace KamilCieślikLab4PD.Model
{
    public class MenuProduct:Entity
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AmountOfCalories { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
