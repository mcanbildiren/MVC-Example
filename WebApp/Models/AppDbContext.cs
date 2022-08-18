using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Kalemler" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 2, Name = "Defterler" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 3, Name = "Silgiler" });

            modelBuilder.Entity<Product>().HasData(new Product() {Id=1, Name = "Kalem 1", Price = 10, Color = "Kırmızı", CategoryId = 1, IsPublish = true });

            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
