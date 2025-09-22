using System.ComponentModel.DataAnnotations;

namespace practik_a5.entities
{
    class Executor
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Disk>? Discs { get; set; }
    }
}