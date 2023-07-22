
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddVideo();
        }

        static void AddVideo()
        {
            using(var context = new VidzyContext())
            {
                System.DateTime dateTime = new System.DateTime(1984, 10, 26);


                //Suitable for WPF Applications
                //var genres = context.Genres.ToList();
                //var genre = context.Genres.Single(a => a.Name == "Action");

                // Suitable for Web applications
                var genreId = context.Genres.Single(a => a.Name == "Action").Id;

                var video = new Video
                {
                    Name = "Terminator 3 Correct Entry",
                    GenreId = genreId,
                    ReleaseDate = dateTime,
                    Classification = Classification.Silver

                };
                context.Videos.Add(video);

                context.SaveChanges();
            }
        }
    }
}
