using data_access_a3.models;
using Microsoft.Data.SqlClient;

namespace practik_a2
{
    public class Sales : IDisposable
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
                             where s.dateOfSale between @startDate and @endDate";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            command.Parameters.AddWithValue("startDate", startDate);
            command.Parameters.AddWithValue("endDate", endDate);
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
                             where c.FullName = @fullname
                             order by s.dateOfSale";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            command.Parameters.AddWithValue("fullname", fullname);
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
        public List<Product> showProducts()
        {
            string text = "select * from Products";

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
        public List<Client> showClients()
        {
            string text = "select * from Client";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Client> clients = new List<Client>();

            while (reader.Read())
            {
                clients.Add(
                    new Client()
                    {
                        Id = (int)reader[0],
                        FullName = (string)reader[1],
                        Email = (string)reader[2],
                        Phone = (string)reader[3],
                        Gender = (char)reader[4],
                        PercentSale = (int)reader[5],
                        Subscribe = (int)reader[6]
                    }
                );
            }
            reader.Close();
            return clients;
        }
        public List<Employee> showEmployees()
        {
            string text = "select * from Employee";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();

            while (reader.Read())
            {
                employees.Add(
                    new Employee()
                    {
                        Id = (int)reader[0],
                        FullName = (string)reader[1],
                        HireDate = (string)reader[2],
                        Gender = (char)reader[3],
                        Salary = (int)reader[4]
                    }
                );
            }
            reader.Close();
            return employees;
        }
        public List<Salle> showSalles()
        {
            string text = "select * from Salles";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Salle> salles = new List<Salle>();

            while (reader.Read())
            {
                salles.Add(
                    new Salle()
                    {
                        Id = (int)reader[0],
                        Price = (int)reader[1],
                        Quantity = (int)reader[2],
                        ProductId = (int)reader[3],
                        EmployeeId = (int)reader[4],
                        ClientId = (int)reader[5],
                        DateOfSale = (string)reader[6]
                    }
                );
            }
            reader.Close();
            return salles;
        }
        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}