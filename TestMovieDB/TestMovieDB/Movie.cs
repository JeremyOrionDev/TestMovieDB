using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TestMovieDB
{
    public class Movie
    {
       
        public Movie()
        {
        }
        
        public Movie(bool adult, string backdrop_path, object belongs_to_collection, int budget, List<Genre> genres, string homepage, int id, string imdb_id, string original_language, string original_title, string overview, double popularity, string poster_path, List<ProductionCompany> production_companies, List<ProductionCountry> production_countries, string release_date, int revenue, int runtime, List<SpokenLanguage> spoken_languages, string status, string tagline, string title, bool video, double vote_average, int vote_count)
        {
            this.adult = adult;
            this.backdrop_path = "https://image.tmdb.org/t/p/w342/" + backdrop_path;
            this.belongs_to_collection = belongs_to_collection;
            this.budget = budget;
            this.Genres = genres;
            this.homepage = homepage;
            this.id = id;
            this.imdb_id = imdb_id;
            this.original_language = original_language;
            this.original_title = original_title;
            this.overview = overview;
            this.popularity = popularity;
            this.poster_path = "https://image.tmdb.org/t/p/w342/" + poster_path;
            this.Production_companies = production_companies;
            this.Production_countries = production_countries;
            this.release_date = release_date;
            this.revenue = revenue;
            this.runtime = runtime;
            this.spoken_languages = spoken_languages;
            this.status = status;
            this.tagline = tagline;
            this.title = title;
            this.video = video;
            this.vote_average = vote_average;
            this.vote_count = vote_count;
            Movies.MoviesDic.Add(Movies.MoviesDic.Count, this);
        }

        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        internal List<Genre> Genres { get; private set; }
        public string homepage { get; set; }
        [Key]
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        internal List<ProductionCompany> Production_companies { get; private set; }
        internal List<ProductionCountry> Production_countries { get; private set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguage> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }
}