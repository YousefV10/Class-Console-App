using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    internal class Theatre :Base 
    {
        private static int _theaterIdCounter = 0;

        private Movie[] _movies = new Movie[0];
        private int Id;

        private Movie[] Movies => _movies;

     

        public Theatre(string name )
        {
            Id = ++_theaterIdCounter;
            Name = name;
        }

        public void  AddMovie (Movie movie)
        {
            if (_movies.Any(m => m.Id == movie.Id))
            {
                Console.WriteLine($"\n!!! Xəbərdarlıq: '{movie.Name}' filmi artıq '{Name}' teatrında göstərilir");
                return;

            }

            int newSize = _movies.Length + 1;
            Movie[] newMovies = new Movie[newSize];

           
            Array.Copy(_movies, newMovies, _movies.Length);

           
            newMovies[newSize - 1] = movie;

       
            _movies = newMovies;

            Console.WriteLine($" '{movie.Name}' filmi '{Name}' teatrının repertuarına əlavə edildi.");


        }

        public void RemoveMovie(Movie movie)
        {
            int indexToRemove = -1; 

            for (int i = 0; i <_movies.Length; i++)
            {
                if (_movies[i].Id == movie.Id)
                {
                    indexToRemove = i;
                    break; 
                }
            }
            if (indexToRemove == -1)
            {
                Console.WriteLine($" '{movie.Name} ' filmi tapilmadi ");
                return; 

            }

            int newSize = _movies.Length - 1;
            Movie[] newMovies = new Movie[newSize];
            int newIndex = 0;

            for (int i = 0; i < _movies.Length; i++)
            {
                if (i != indexToRemove)
                {
                    newMovies[newIndex++] = _movies[i];
                }
            }

            _movies = newMovies;

            Console.WriteLine( $" {movie.Name} ugurla cixarildi ");


        }

        public override string ToString()
        {
            return $"{Id}. Teatr : {Name}";
        }
    }
}
