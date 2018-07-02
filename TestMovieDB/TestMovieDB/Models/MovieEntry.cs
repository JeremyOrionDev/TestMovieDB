using System;
using System.Collections.Generic;
using System.Text;

namespace TestMovieDB.Models
{
    public class MovieEntry
    {
        public MovieEntry()
        {
        }

        public MovieEntry(int iD, string title, string overview, string posterPath, string backDropPath)
        {
            this.iD = iD;
            this.title = title;
            this.overview = overview;
            this.posterPath = posterPath;
            this.backDropPath = backDropPath;
        }

        public int iD { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string posterPath { get; set; }
        public string backDropPath { get; set; }
    }
}
