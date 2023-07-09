using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_First_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyDbContext();

            context.AddVideo("Video 15", DateTime.Now, "Comedy",(byte)ClassificationLevel.Platinum);
            context.AddVideo("Video 16", DateTime.Now, "Action", (byte)ClassificationLevel.Platinum);



        }
    }
}
