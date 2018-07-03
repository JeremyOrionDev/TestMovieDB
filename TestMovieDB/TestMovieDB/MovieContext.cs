using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace TestMovieDB
{
    public class MovieContext: System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Movie> Movies { get; set; }

        private string DatabasePath { get; set; }

        public MovieContext()
        {

        }

        public MovieContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

  
    }
}
