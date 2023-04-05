using API_web.Models;
using Microsoft.EntityFrameworkCore;

namespace API_web.Data
{
    public class WebDbContext:DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasKey(cp => new { cp.CategoryId, cp.ProductId });
        }
    }
}
