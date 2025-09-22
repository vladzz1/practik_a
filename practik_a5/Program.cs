namespace practik_a5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tools -> NuGet Package Maneger -> Package Maneger Console -> add-migration назва -> update-database

            musicAppDbContext context = new musicAppDbContext();

            //var songs = context.Discs.Where(item => item.DiskName == "et tempus");
            //songs = context.Songs.Where();

            var tracks = context.Discs.Take(3);
            var albums = context.Songs.Take(3);

            foreach (var track in tracks)
            {
                Console.WriteLine($"Disk Name = {track.DiskName}, Release Date = {track.ReleaseDate.ToString("yyyy-mm-dd")}, Rating = {track.Rating}");
            }
            Console.WriteLine("\n------------------------------------------------------");
            foreach (var album in albums)
            {
                Console.WriteLine($"Song Title = {album.SongTitle}, Song Length = {album.SongLength}, Rating = {album.Rating}, Number Of Listenings = {album.NumberOfListenings}, Track Text = {album.TrackText}");
            }
        }
    }
}
