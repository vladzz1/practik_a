namespace practik_a6.entities
{
    class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public bool IsInStock { get; set; }
        public ICollection<Shop>? Shops { get; set; }
    }
}
