using FluentAPI.Migrations.EntityConfigurations;
using System.Data.Entity;

namespace DataAnnotations
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //we are chaining method calls thats why this is called as fluent api
            modelBuilder.Configurations.Add(new CourceConfiguration());
        }
    }
}