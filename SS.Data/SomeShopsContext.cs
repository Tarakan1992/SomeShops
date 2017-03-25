using Microsoft.EntityFrameworkCore;
using SS.Entities;

namespace SS.Data
{
    public class SomeShopsContext : DbContext
    {
        public DbSet<Shop> Shops { get; }
        public DbSet<Product> Products { get; }

        public SomeShopsContext(DbContextOptions<SomeShopsContext> options)
            : base(options)
        {
        }
    }
}
