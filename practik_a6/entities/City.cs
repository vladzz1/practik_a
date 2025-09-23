namespace practik_a6.entities
{
    class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Shop>? Shops { get; set; }
        public Country? Country { get; set; }
        public int CountryId { get; set; }
    }
}
