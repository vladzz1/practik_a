using data_access_a3.models;

namespace practik_a2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = DESKTOP-B6M267U\SQLEXPRESS; Initial Catalog = Sales; Integrated Security = true; TrustServerCertificate = True;";

            //Product product = new Product()
            //{
            //    Name = "Сандалі",
            //    Type = "Взуття",
            //    Quantity = 6,
            //    Cost = 5000,
            //    Producer = "Італія",
            //    Price = 6000
            //};
            using (SalesDb sales = new SalesDb(connectionString))
            {
                //sales.addOneProduct(product);

                var products = sales.showAllSalesForACertainPeriod("2021-04-06", "2023-12-16");
                foreach (var p in products)
                {
                    Console.WriteLine(p.ToString());
                }

                Product oneProduct = sales.showLatestProductByName("Петрук Степан Романович");
                Console.WriteLine(oneProduct);

                //sales.deleteSellerOrCustomerById(2, false);

                Employee oneEmployee = sales.showSellerTotalSalesAmountIsTheLargest();
                Console.WriteLine(oneEmployee);
            }
        }
    }
}