using System.ComponentModel.DataAnnotations;

namespace practik_a5.entities
{
    class Disk
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? DiskName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Style? Style { get; set; }
        public int StyleId { get; set; }
        public Executor? Executor { get; set; }
        public int ExecutorId { get; set; }
        public Publisher? Publisher { get; set; }
        public int PublisherId { get; set; }
        public ICollection<Song>? Songs { get; set; }
        public int Rating { get; set; }
    }
}