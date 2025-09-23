namespace practik_a6.entities
{
    class Worker
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Position? Position { get; set; }
        public int PositionId { get; set; }
        public Shop? Shop { get; set; }
        public int ShopId { get; set; }
    }
}
