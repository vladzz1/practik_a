using Microsoft.EntityFrameworkCore;
using practik_a5.entities;

namespace practik_a5
{
    class musicAppDbContext : DbContext
    {
        public musicAppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Disk> Discs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-B6M267U\\SQLEXPRESS; Initial Catalog = practik_a5; Integrated Security = true; TrustServerCertificate = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Style>().HasData(new Style[]
            {
                new Style()
                {
                    Id = 1,
                    Name = "vivamus metus"
                },
                new Style()
                {
                    Id = 2,
                    Name = "congue elementum"
                },
                new Style()
                {
                    Id = 3,
                    Name = "id sapien"
                }
            });
            modelBuilder.Entity<Executor>().HasData(new Executor[]
            {
                new Executor()
                {
                    Id = 1,
                    Name = "Bella",
                    LastName = "Spiers",
                    DateOfBirth = new DateTime(2017, 02, 01)
                },
                new Executor()
                {
                    Id = 2,
                    Name = "Janina",
                    LastName = "Chong",
                    DateOfBirth = new DateTime(2008, 10, 15)
                },
                new Executor()
                {
                    Id = 3,
                    Name = "Cinnamon",
                    LastName = "Sotheron",
                    DateOfBirth = new DateTime(2003, 04, 18)
                }
            });
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country()
                {
                    Id = 1,
                    Name = "Papua New Guinea"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Kenya"
                },
                new Country()
                {
                    Id = 3,
                    Name = "China"
                }
            });
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher()
                {
                    Id = 1,
                    Name = "consequat metus",
                    CountryId = 2
                },
                new Publisher()
                {
                    Id = 2,
                    Name = "sapien",
                    CountryId = 1
                },
                new Publisher()
                {
                    Id = 3,
                    Name = "eu interdum",
                    CountryId = 3
                }
            });
            modelBuilder.Entity<Disk>().HasData(new Disk[]
            {
                new Disk()
                {
                    Id = 1,
                    DiskName = "at vulputate",
                    ReleaseDate = new DateTime(2017, 04, 07),
                    StyleId = 1,
                    ExecutorId = 1,
                    PublisherId = 1
                },
                new Disk()
                {
                    Id = 2,
                    DiskName = "et tempus",
                    ReleaseDate = new DateTime(2012, 01, 16),
                    StyleId = 2,
                    ExecutorId = 2,
                    PublisherId = 2
                },
                new Disk()
                {
                    Id = 3,
                    DiskName = "vel enim",
                    ReleaseDate = new DateTime(2021, 04, 27),
                    StyleId = 3,
                    ExecutorId = 3,
                    PublisherId = 3
                }
            });
            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song()
                {
                    Id = 1,
                    SongTitle = "turpis adipiscing lorem",
                    SongLength = 536,
                    DiskId = 1
                },
                new Song()
                {
                    Id = 2,
                    SongTitle = "faucibus orci luctus et",
                    SongLength = 526,
                    DiskId = 2
                },
                new Song()
                {
                    Id = 3,
                    SongTitle = "odio consequat varius",
                    SongLength = 384,
                    DiskId = 3
                }
            });
        }
    }
}