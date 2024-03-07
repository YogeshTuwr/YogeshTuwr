using Microsoft.EntityFrameworkCore;

namespace CatalogService.Database
{
    public class DatabaseContext:DbContext
    {
        //public DatabaseContext(DatabaseContextOptions<DatabaseContext> options) :base(options)

        //{

        //}
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
