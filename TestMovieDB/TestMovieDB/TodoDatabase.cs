using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace TestMovieDB
{
    internal class MovieDatabase
    {
        static object locker = new object();

        public SQLiteConnection database;

        public string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        public MovieDatabase(SQLiteConnection conn)
        {
            database = conn;
            // create the tables
            database.CreateTable<Movie>();
        }

        public IEnumerable<Movie> GetMovies()
        {
            lock (locker)
            {
                return (from i in database.Table<Movie>() select i).ToList();
            }
        }

        public Movie GetMovieFromId(int id)
        {
            lock (locker)
            {
                return database.Table<Movie>().FirstOrDefault(x => x.id == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
        }

        public int SaveMovie(Movie item)
        {
            lock (locker)
            {
                if (item.id != 0)
                {
                    database.Update(item);
                    return item.id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int Deletemovie(int id)
        {
            lock (locker)
            {
                return database.Delete<Movie>(id);
            }
        }
    }
}