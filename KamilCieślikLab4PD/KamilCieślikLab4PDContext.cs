using KamilCieślikLab4PD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD
{
    public class KamilCieślikLab4PDContext : DbContext
    {
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<MenuProduct> MenuProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public KamilCieślikLab4PDContext(): base("name=KamilCieślikLab4PDContext")
        {

        }

    }
}
