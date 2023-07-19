using System.Linq;
namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //get data using linq syntax

            var query =
                from c in context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;


            foreach (var cource in query)
            {
                System.Console.WriteLine(cource.Name);
            }


            //get data using extension methods

            var courses = context.Courses
                                  .Where(c => c.Name.Contains("c#"))
                                  .OrderBy(c => c.Name);

            foreach (var cource in query)
            {
                System.Console.WriteLine(cource.Name);
            }

        }
    }
}
