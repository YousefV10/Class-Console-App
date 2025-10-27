using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    internal class Movie : Base 
    {
        private static int _movieIdCounter = 0;
        public string Director { get; set;  }
        public Genre Genre { get; set;  }
        public string AgeLimit { get; set; }
        public int Id { get; }

        public Movie(string name ,string directro ,Genre genre, string ageLimit)
        {
            Id = ++_movieIdCounter;
            Name = name;
            Director = directro;
            Genre = genre;
            AgeLimit = AgeLimit; 
        }

        public override string ToString()
        {
            return $"{Id}. Film: {Name}, Rejissor: {Director}, Janr: {Genre.Name}, Yaş Məhdudiyyəti: {AgeLimit}";
        }
    }
}
