using Microsoft.EntityFrameworkCore;
using practik_a6.entities;

namespace practik_a6.helpers
{
    static class DbInitializer
    {
        public static void seedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category()
                {
                    Id = 1,
                    Name = "category1"
                },
                new Category()
                {
                    Id = 2,
                    Name = "category2"
                },
                new Category()
                {
                    Id = 3,
                    Name = "category3"
                }
            });
        }
        public static void seedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City()
                {
                    Id = 1,
                    Name = "city1",
                    CountryId = 1
                },
                new City()
                {
                    Id = 2,
                    Name = "city2",
                    CountryId = 1
                },
                new City()
                {
                    Id = 3,
                    Name = "city3",
                    CountryId = 2
                }
            });
        }
        public static void seedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country()
                {
                    Id = 1,
                    Name = "country1"
                },
                new Country()
                {
                    Id = 2,
                    Name = "country2"
                }
            });
        }
        public static void seedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                new Position()
                {
                    Id = 1,
                    Name = "position1"
                },
                new Position()
                {
                    Id = 2,
                    Name = "position2"
                },
                new Position()
                {
                    Id = 3,
                    Name = "position3"
                }
            });
        }
        public static void seedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "product1",
                    Price = 45,
                    Discount = 5,
                    CategoryId = 2,
                    Quantity = 20,
                    IsInStock = true
                },
                new Product()
                {
                    Id = 2,
                    Name = "product2",
                    Price = 31,
                    Discount = 2,
                    CategoryId = 1,
                    Quantity = 34,
                    IsInStock = true
                },
                new Product()
                {
                    Id = 3,
                    Name = "product3",
                    Price = 54,
                    Discount = 4,
                    CategoryId = 3,
                    Quantity = 0,
                    IsInStock = false
                }
            });
        }
        public static void seedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop[]
            {
                new Shop()
                {
                    Id = 1,
                    Name = "shop1",
                    Address = "address1",
                    CityId = 2,
                    ParkingArea = 60
                },
                new Shop()
                {
                    Id = 2,
                    Name = "shop2",
                    Address = "address2",
                    CityId = 1,
                    ParkingArea = 20
                },
                new Shop()
                {
                    Id = 3,
                    Name = "shop3",
                    Address = "address3",
                    CityId = 3,
                    ParkingArea = 150
                }
            });
        }
        public static void seedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(new Worker[] 
            {
                new Worker()
                {
                    Id = 1,
                    Name = "worker1",
                    SurName = "surname1",
                    Salary = 4500,
                    Email = "email1",
                    PhoneNumber = "phone number1",
                    PositionId = 1,
                    ShopId = 3
                },
                new Worker()
                {
                    Id = 2,
                    Name = "worker2",
                    SurName = "surname2",
                    Salary = 5700,
                    Email = "email2",
                    PhoneNumber = "phone number2",
                    PositionId = 2,
                    ShopId = 2
                },
                new Worker()
                {
                    Id = 3,
                    Name = "worker3",
                    SurName = "surname3",
                    Salary = 6000,
                    Email = "email3",
                    PhoneNumber = "phone number3",
                    PositionId = 3,
                    ShopId = 1
                }
            });
        }
    }
}
