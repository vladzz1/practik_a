using System.ComponentModel.DataAnnotations;

namespace practik_a5.entities
{
    class Style
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public ICollection<Disk>? Discs { get; set; }
    }
}