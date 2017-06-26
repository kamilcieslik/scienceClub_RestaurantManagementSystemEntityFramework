using KamilCieślikLab4PD.Model;
using System.Data.Entity;

namespace KamilCieślikLab4PD
{
    public class KamilCieślikLab4PdContext : DbContext
    {
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<MenuProduct> MenuProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public KamilCieślikLab4PdContext(): base("name=KamilCieślikLab4PdContext")
        {

        }
    }
}
