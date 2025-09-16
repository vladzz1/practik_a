namespace practik_a2_2
{
    class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
        public string? Producer { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Name,15}  {Type,15} {Quantity,5} {Cost,5} {Producer,15} {Price,5}";
        }
    }
}
