

using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var videos = context.Videos.ToList();

            foreach (var vid in videos)
            {
                System.Console.WriteLine($"Name = {vid.Name} : Genre = {vid.Genre.Name}");
            }
        }
    }
}
