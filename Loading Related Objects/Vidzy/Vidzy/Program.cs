

using System.Linq;

//for using lambda expression in Include methodc =
using System.Data.Entity;
namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();


            //Lazy loading
            //var videos = context.Videos.ToList();

            //foreach (var vid in videos)
            //{
            //    System.Console.WriteLine($"Name = {vid.Name} : Genre = {vid.Genre.Name}");
            //}



            //eager Loading
            var videos2 = context.Videos.Include(c => c.Genre).ToList();
            foreach (var vid in videos2)
            {
                System.Console.WriteLine($"Name = {vid.Name} : Genre = {vid.Genre.Name}");
            }

        }
    }
}
