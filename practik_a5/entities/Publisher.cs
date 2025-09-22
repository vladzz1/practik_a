using System.ComponentModel.DataAnnotations;

namespace practik_a5.entities
{
    class Publisher
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public Country? Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Disk>? Discs { get; set; }
    }
}