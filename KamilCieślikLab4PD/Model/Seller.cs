using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Model
{
    public class Seller:Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int YearsOfExperience { get; set; }
        [Required]
        public string EnglishLevel { get; set; }
   

        public Seller()
        {
            
        }

    }
}
