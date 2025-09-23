namespace practik_a6.entities
{
    class Position
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Worker>? Workers { get; set; }
    }
}
