using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Exercise
{
    class VidzyContext : DbContext
    {
        public VidzyContext() : base(nameOrConnectionString:"VidzyContext")
        {
        }


        public DbSet<Video> Videos { get; set; }

        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Video>()
                .HasRequired(c => c.Genre)
                .WithMany(c => c.Videos)
                .HasForeignKey(c => c.GenreId);


            modelBuilder.Entity<Genre>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Video>()
                .HasMany(c => c.Tags)
                .WithMany(c => c.Videos)
                .Map(m =>
                {
                    m.ToTable("VodeoTags");
                    m.MapLeftKey("VideoId");
                    m.MapRightKey("TagId");
                    });
        }
    }
}
