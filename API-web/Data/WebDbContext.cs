using API_web.Models;
using Microsoft.EntityFrameworkCore;

namespace API_web.Data
{
    public class WebDbContext:DbContext
    {
        public WebDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rating> ratings { get; set; }
        #endregion

    }
}
