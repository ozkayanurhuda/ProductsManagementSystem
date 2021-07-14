using System.Data.Entity;

namespace EntityFramework
{
    public class ECommerceContext : DbContext
    {
        //tablolarda Product arar
        public DbSet<Product> Products { get; set; }
    }
}
