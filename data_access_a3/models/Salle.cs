namespace data_access_a3.models
{
    class Salle
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public string? DateOfSale { get; set; }
        public override string ToString()
        {
            return $"{Price,15}  {Quantity,15} {ProductId,5} {EmployeeId,5} {ClientId,15} {DateOfSale,5}";
        }
    }
}
