using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    internal class Genre :Base 
    {
        private static int _genreId = 0;
        public int Id { get; }

        public Genre (string name)
        {
            Name = name;
            Id = ++_genreId;
        }
        public override string ToString()
        {
            return $"{Id} , Genre : {Name}";
        }
       
    }
}
