using SQLite;
using System.Collections.Generic;

namespace TestMovieDB
{
    internal class MovieRepository
    {
        MovieDatabase db = null;

        public MovieRepository(SQLiteConnection conn)
        {
            db = new MovieDatabase(conn);
        }

        public Movie GetMovie(int id)
        {
            return db.GetMovieFromId(id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return db.GetMovies();
        }

        public int SaveMovie(Movie item)
        {
            return db.SaveMovie(item);
        }

        public int DeleteMovie(int id)
        {
            return db.Deletemovie(id);
        }
    }
}