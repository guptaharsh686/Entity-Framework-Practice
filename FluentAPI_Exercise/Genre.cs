using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Exercise
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Video> Videos { get; set; }
    }
}
