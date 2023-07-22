
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddVideo();
            //AddTags();
            //AddTags();

            //AddTagsToVideo();
            //AddTagsToVideo();

            //RemoveComedyTag();

            //RemoveVideo();

            RemoveGenre();


        }

        static void RemoveGenre()
        {
            using(var context = new VidzyContext())
            {
                var genreAvailable = context.Genres.Select(a => a.Id).ToList().Contains(2);
                if (genreAvailable)
                {
                    var genre = context.Genres.Include(a => a.Videos).Single(a => a.Id == 2);

                    //first remove all the films related to that genre
                    context.Videos.RemoveRange(genre.Videos);
                    //then remove genre
                    context.Genres.Remove(genre);
                }
                context.SaveChanges();
            }
        }

        static void RemoveVideo()
        {
            using(var context = new VidzyContext())
            {
                var videoavailable = context.Videos.Select(a => a.Id).Contains(1);

                if(videoavailable)
                {
                    var video = context.Videos.Single(a => a.Id == 1);
                    context.Videos.Remove(video);
                }

                context.SaveChanges();

            }
        }

        static void RemoveComedyTag()
        {
            using(var context = new VidzyContext())
            {
                var video = context.Videos.Single(a => a.Id == 1);

                if(video.Tags.Any(a => a.Name == "comedy"))
                {
                    video.Tags.Remove(video.Tags.Single(a => a.Name == "comedy"));
                }

                context.SaveChanges();
            }
        }
        static void AddTagsToVideo()
        {
            using(var context = new VidzyContext())
            {
                var video = context.Videos.Single(a => a.Id == 1);
                var classicTag = context.Tags.Single(a => a.Name == "classics");
                var dramaTag = context.Tags.Single(a => a.Name == "drama");
                var comedyTag = new Tag
                {
                    Name = "comedy"
                };
                


                video.Tags.Add(classicTag);
                video.Tags.Add(dramaTag);

                if (!context.Tags.Select(a => a.Name).ToList().Contains("comedy"))
                {
                    context.Tags.Add(comedyTag);
                    video.Tags.Add(comedyTag);
                }


                context.SaveChanges();
            }
        }

        static void AddTags()
        {
            using(var context = new VidzyContext())
            {
                var classicTag = new Tag
                {
                    Name = "classics",
                };

                var dramaTag = new Tag
                {
                    Name = "drama",
                };

                if(!context.Tags.Select(a => a.Name).ToList().Contains(classicTag.Name))
                    context.Tags.Add(classicTag);
                if (!context.Tags.Select(a => a.Name).ToList().Contains(dramaTag.Name))
                     context.Tags.Add(dramaTag);

                context.SaveChanges();
            }
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
