

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var videos = context.Videos;

            foreach (var vid in videos)
            {
                System.Console.WriteLine($"Name = {vid.Name} : Genre = {vid.Genre.Name}");
            }
        }
    }
}
