using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Model
{
    public abstract class Entity
    {
        [Key]
        public int ID { get; set; }
        
    }
}
