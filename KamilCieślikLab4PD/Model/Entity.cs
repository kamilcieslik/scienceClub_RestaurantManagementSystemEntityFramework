using System.ComponentModel.DataAnnotations;

namespace KamilCieślikLab4PD.Model
{
    public abstract class Entity
    {
        [Key]
        public int ID { get; set; }       
    }
}
