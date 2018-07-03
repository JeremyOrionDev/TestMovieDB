using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestMovieDB
{
    public class Movies
    {
        private static Dictionary<int,Movie> moviesDic = new Dictionary<int, Movie>();
 
        public static Dictionary<int,Movie> MoviesDic { get => moviesDic; private set => moviesDic = value; }
        internal  static List<Movie> MoviesToList()
        {
            List<Movie> laliste = new List<Movie>();
            foreach (KeyValuePair<int, Movie> item in MoviesDic)
            {
                laliste.Add(item.Value);
            }
            return laliste;
        }
        public static Movie getMovie(int id)
        {
            
            if (MoviesDic.TryGetValue(id,out Movie m))
            {

                return m;
            }
            else
            {
                throw new KeyNotFoundException("Le film d'id:" + id + " n'a pas été trouvé dans la base de donnée");
            }
        }
        public static void updateMovie(int id,Movie mov)
        {
            
            if (MoviesDic.TryGetValue(id,out Movie m))
            {
                m = mov;
            }
            else
            {
                throw new KeyNotFoundException("Le film d'id:" + id + " n'a pas été trouvé dans la base de donnée");
            }
        }

    }
}
