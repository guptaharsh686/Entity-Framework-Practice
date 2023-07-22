using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            // Action movies sorted by name
            dynamic result = context.Videos.Where(v => v.Genre.Name == "Action").OrderBy(v => v.Name);


            //  Gold drama movies sorted by release date (newest first)
            result = context.Videos.Where(v => v.Classification == Classification.Gold && v.Genre.Name == "Drama").OrderByDescending(v => v.ReleaseDate);

            //  All movies projected into an anonymous type with two properties: MovieName and Genre

            result = context.Videos.Select(v => new
            {
                Name = v.Name,
                Genre = v.Genre.Name
            });

            //foreach (var res in result)
            //{
            //    System.Console.WriteLine(res.Name);
            //}

            /*
                All movies grouped by their classification: Project the group into a new 
                anonymous type with two properties: Classification (string), Movies 
                (IEnumerable<Video>). For each group, display the classification and list of 
                videos in that class sorted alphabetically.
             */

            result = context.Videos.GroupBy(v => v.Classification).Select(group => new {
                classification = group.Key,
                Movies = group.OrderBy(g => g.Name)
            });

            //foreach (var res in result)
            //{
            //    System.Console.WriteLine(res.classification);
            //    foreach (var item in res.Movies)
            //    {
            //        System.Console.WriteLine("\t"+item.Name);
            //    }
            //}

            //List of classifications sorted alphabetically and count of videos in them. 

            result = context.Videos.GroupBy(v => v.Classification).OrderBy(v => v.Key.ToString()).Select(v => new
            {
                classification = v.Key,
                count = v.Count()
            });

            //foreach (var res in result)
            //{
            //    System.Console.WriteLine(res.classification);
            //    System.Console.WriteLine(res.count);
            //}


            /*
              List of genres and number of videos they include, sorted by the number 
              of videos. Genres with the highest number of videos come first. 
             */

            result = context.Genres.GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, video) => new
            {
                genre = genre.Name,
                videoCount = video.Count()
            }).OrderByDescending(x => x.videoCount);

            foreach (var res in result)
            {
                System.Console.WriteLine(res.genre);
                System.Console.WriteLine(res.videoCount);
            }



        }
    }
}
