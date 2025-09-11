using Microsoft.Data.SqlClient;

namespace practik_a2
{
    class Sales : IDisposable
    {
        private SqlConnection sqlConnection;
        public Sales(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        public void addOneProduct(Product product)
        {
            string text = $@"insert into Products values 
                                ('{product.Name}', 
                                '{product.Type}',
                                {product.Quantity}, 
                                {product.Cost}, 
                                '{product.Producer}', 
                                {product.Price})";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            command.CommandTimeout = 5; // default - 30sec

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected");
        }
        public List<Product> showAllSalesForACertainPeriod(string startDate, string endDate)
        {
            string text = $@"select p.Name, p.TypeProduct, p.Quantity, p.CostPrice, p.Producer, p.Price
                             from Products as p join Salles as s on p.Id = s.ProductId
                             where s.dateOfSale between '{startDate}' and '{endDate}'";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(
                    new Product()
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Type = (string)reader[2],
                        Quantity = (int)reader[3],
                        Cost = (int)reader[4],
                        Producer = (string)reader[5],
                        Price = (int)reader[6]
                    }
                ); 
            }
            reader.Close();
            return products;
        }
        public Product showLatestProductByName(string fullname)
        {
            string text = $@"select top 1 p.[Name], p.TypeProduct, p.Quantity, p.CostPrice, p.Producer, p.Price
                             from Products as p join Salles as s on p.Id = s.ProductId join Clients as c on s.ClientId = c.Id
                             where c.FullName = '{fullname}'
                             order by s.dateOfSale";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Product product = new Product();
            while (reader.Read())
            {
                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.Cost = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];
            }

            reader.Close();
            return product;
        }
        public void deleteSellerOrCustomerById(int id, bool seller)
        {
            string text;
            if (seller)
            {
                text = $@"delete Employees where Id = {id}";
            }
            else
            {
                text = $@"delete Clients where Id = {id}";
            }


            SqlCommand command = new SqlCommand(text, sqlConnection);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected");
        }
        public Employee showSellerTotalSalesAmountIsTheLargest()
        {
            string text = $@"select top 1 e.FullName, e.HireDate, e.Gender, e.Salary
                             from Employees as e join Salles as s on e.Id = s.EmployeeId
                             group by e.FullName, e.HireDate, e.Gender, e.Salary
                             order by sum(s.Price)";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            command.CommandTimeout = 5; // default - 30sec

            SqlDataReader reader = command.ExecuteReader();

            Employee employee = new Employee();
            while (reader.Read())
            {
                employee.Id = (int)reader[0];
                employee.FullName = (string)reader[1];
                employee.HireDate = (string)reader[2];
                employee.Gender = (char)reader[3];
                employee.Salary = (int)reader[4];

            }

            reader.Close();
            return employee;
        }
        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
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
            using (Sales sales = new Sales(connectionString))
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