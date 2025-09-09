using Microsoft.Data.SqlClient;

namespace practik_a
{
    internal class Program
    {
        static void showAllBuyers(SqlConnection sqlConnection)
        {
            string text = @"select * from Clients";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i), 10}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i], 10} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        static void showAllEmployees(SqlConnection sqlConnection)
        {
            string text = @"select * from Employees";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i), 10}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i], 10} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        static void showSellerInformation(SqlConnection sqlConnection)
        {
            string text = @"select p.Name, p.TypeProduct, p.Quantity, p.CostPrice, p.Producer, p.Price 
                            from Products as p join Salles as s on p.Id = s.ProductId join Employees as e on s.EmployeeId = e.Id
                            where e.FullName = N'Ярощук Іван Петрович'";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),10}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],10} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        static void showSalesInformation(SqlConnection sqlConnection)
        {
            string text = @"select p.Name, p.TypeProduct, p.Quantity, p.CostPrice, p.Producer, p.Price 
                            from Products as p
                            where p.Price > 350";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),10}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],10} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        static void showMaxAndMinPrice(SqlConnection sqlConnection)
        {
            string text = @"select max(p.Price) as 'max price', min(p.Price) as 'min price' 
                            from Products as p join Salles as s on p.Id = s.ProductId join Clients as c on s.ClientId = c.Id
                            where c.FullName = N'Петрук Степан Романович'";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),10}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],10} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        static void showTheVeryFirstSale(SqlConnection sqlConnection)
        {
            string text = @"select top 1 p.Name, p.TypeProduct, p.Quantity, p.CostPrice, p.Producer, p.Price
                            from Products as p join Salles as s on p.Id = s.ProductId join Employees as e on s.EmployeeId = e.Id
                            where e.FullName = N'Михальчук Руслана Романівна'
                            order by s.dateOfSale desc";

            SqlCommand command = new SqlCommand(text, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),10}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],10} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = DESKTOP-B6M267U\SQLEXPRESS; Initial Catalog = Sales; Integrated Security = true; TrustServerCertificate = True;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Conected");

            showAllBuyers(sqlConnection);

            showAllEmployees(sqlConnection);

            showSellerInformation(sqlConnection);

            showSalesInformation(sqlConnection);

            showMaxAndMinPrice(sqlConnection);

            showTheVeryFirstSale(sqlConnection);

            sqlConnection.Close();
        }
    }
}
