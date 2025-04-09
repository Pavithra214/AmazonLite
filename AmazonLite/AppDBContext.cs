using AmazonLite.Models;
using Microsoft.EntityFrameworkCore;
namespace AmazonLite
{
    public class AppDBContext:DbContext
    {
        public DbSet<ProdList> ProdLists { get; set; }
        public DbSet<BrandList> BrandLists { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
