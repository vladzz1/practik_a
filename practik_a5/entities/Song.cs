using System.ComponentModel.DataAnnotations;

namespace practik_a5.entities
{
    class Song
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? SongTitle { get; set; }
        public int SongLength { get; set; }
        public Disk? Disk { get; set; }
        public int DiskId { get; set; }
        public int Rating { get; set; }
        public int NumberOfListenings { get; set; }
        public string? TrackText { get; set; }
    }
}