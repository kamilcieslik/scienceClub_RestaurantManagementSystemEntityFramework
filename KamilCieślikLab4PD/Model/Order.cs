using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Model
{
    public class Order : Entity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int SellerID { get; set; }
        [Required]
        public int Price { get; set; }
        public int AmountOfCalories { get; set; }
        public virtual IList<MenuProduct> Products { get; set; }

        public Order()
        {
            Date = DateTime.Now;
        }
    }
}
