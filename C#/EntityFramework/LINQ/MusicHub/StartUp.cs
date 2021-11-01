namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var producer = context
                .Producers
                .Where(p => p.Id == producerId)
                .Include(p => p.Albums)
                .ThenInclude(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .FirstOrDefault();

            foreach (var album in producer.Albums.OrderByDescending(a => a.Price))
            {
                var songNumber = 1;

                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {producer.Name}");
                sb.AppendLine($"-Songs:");

                foreach (var song in album.Songs.OrderByDescending(s => s.Name)
                                                .ThenBy(s => s.Writer.Name))
                {
                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                    songNumber++;
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");

            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int durationInSeconds)
        {
            StringBuilder sb = new StringBuilder();

            var songsAboveDuration = context
                .Songs
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                .ThenBy(s => s.SongPerformers.Count)
                .ToList()
                .Where(s => ((int)s.Duration.TotalSeconds) > durationInSeconds)
                .ToList();

            var songNumber = 1;
            foreach (var song in songsAboveDuration)
            {
                var performer = song.SongPerformers.FirstOrDefault();

                sb.AppendLine($"-Song #{songNumber}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer.Name}");
                sb.AppendLine($"---Performer: {(performer != null ? $"{performer.Performer.FirstName} {performer.Performer.LastName}" : null)}");
                sb.AppendLine($"---AlbumProducer: {song.Album.Producer.Name}");
                sb.AppendLine($"---Duration: {song.Duration}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
