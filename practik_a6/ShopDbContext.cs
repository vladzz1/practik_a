using Microsoft.EntityFrameworkCore;
using practik_a6.entities;
using practik_a6.helpers;

namespace practik_a6
{
    class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public ShopDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-B6M267U\\SQLEXPRESS; Initial Catalog = practik_a6; Integrated Security = true; TrustServerCertificate = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Position>().Property(p => p.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Shop>().Property(s => s.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Shop>().Property(s => s.Address).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Worker>().Property(w => w.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Worker>().Property(w => w.SurName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Worker>().Property(w => w.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Worker>().Property(w => w.PhoneNumber).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Position>().HasMany(p => p.Workers).WithOne(w => w.Position).HasForeignKey(w => w.PositionId);
            modelBuilder.Entity<Worker>().HasOne(w => w.Shop).WithMany(s => s.Workers).HasForeignKey(w => w.ShopId);
            modelBuilder.Entity<Shop>().HasMany(s => s.Products).WithMany(p => p.Shops);
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Shop>().HasOne(s => s.City).WithMany(c => c.Shops).HasForeignKey(s => s.CityId);
            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(c => c.CountryId);

            modelBuilder.seedPositions();
            modelBuilder.seedCountries();
            modelBuilder.seedCities();
            modelBuilder.seedCategories();
            modelBuilder.seedProducts();
            modelBuilder.seedShops();
            modelBuilder.seedWorkers();
        }
    }
}
