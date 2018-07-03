using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMovieDB
{
    class MovieItemManager
    {
        MovieRepository repository;

        public MovieItemManager(SQLiteConnection conn)
        {
            repository = new MovieRepository(conn);
        }

        public Movie GetMovie(int id)
        {
            return repository.GetMovie(id);
        }

        public IList<Movie> GetMovies()
        {
            return new List<Movie>(repository.GetMovies());
        }

        public int SaveTask(Movie item)
        {
            return repository.SaveMovie(item);
        }

        public int DeleteMovie(int id)
        {
            return repository.DeleteMovie(id);
        }
    }
}
