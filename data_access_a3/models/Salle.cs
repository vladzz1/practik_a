namespace data_access_a3.models
{
    public class Salle
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateOfSale { get; set; }
        public override string ToString()
        {
            return $"{Price,15}  {Quantity,15} {ProductId,5} {EmployeeId,5} {ClientId,15} {DateOfSale,5}";
        }
    }
}
