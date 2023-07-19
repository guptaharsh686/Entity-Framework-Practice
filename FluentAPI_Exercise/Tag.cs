using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Exercise
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; private set; }

        public Tag()
        {
            Videos = new HashSet<Video>();
        }
    }
}
