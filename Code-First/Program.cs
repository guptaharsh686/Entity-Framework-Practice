using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }
        public CourseLevel Level { get; set; }

        public Author Author { get; set; }

        public IList<Tag> Tags { get; set; }


    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }



    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public enum CourseLevel
    {
        Beginer = 1,
        Intermediate,
        Advanced
    }

    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base(nameOrConnectionString:"DefaultConnection")
        {

        }


        //Defining DbSet
        //DbSet - A Collection of objects that represent a table in the database
        public DbSet<Course> Courses { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}