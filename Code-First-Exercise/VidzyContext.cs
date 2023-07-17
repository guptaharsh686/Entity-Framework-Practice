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
    }
}
