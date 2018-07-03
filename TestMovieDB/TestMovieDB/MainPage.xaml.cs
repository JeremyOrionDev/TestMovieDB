using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TestMovieDB.Models;
using Xamarin.Forms;
using TestMovieDB;
using System.Data;
using SQLitePCL;
using SQLite;

namespace TestMovieDB
{
	public partial class MainPage : ContentPage 
	{
        //var sqliteFilename = "TodoItemDB.db3";

       
        public static void updateMovie(int id)
        {
            string url= "https://api.themoviedb.org/3/movie/"+id+"12?api_key=85a1114cc9bcee8c748abdaaade8169a&language=en-US";
            var req = WebRequest.CreateHttp(url);
            try
            {
                using (var resp=req.GetResponse())
                {
                    string X = resp.ToString();
                    Movie m = JsonConvert.DeserializeObject<Movie>(X);
                    Movies.updateMovie(id, m);
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string respStr = sr.ReadToEnd();
                        int statusCode = (int)response.StatusCode;

                        string errorMsh = $"Request ({url}) failed ({statusCode}) on, with error: {respStr}";
                        throw new WebException(errorMsh);
                    }
                }
            }
        }
        public static List<Movie> getDataFile(string Uri)
        {
            var req = WebRequest.CreateHttp(Uri);
            List<Movie> result= new List<Movie> ();
            /*
                * Headers
                */
            req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";

            /*
                * Execute
                */
            try
            {
                using (var resp = req.GetResponse())
                {
                    using (var str = resp.GetResponseStream())
                    using (var gsr = new GZipStream(str, CompressionMode.Decompress))
                    using (var sr = new StreamReader(gsr))
                    {
                        
                        do
                        {
                            string A = sr.ReadLine();
                            DataSet D = JsonConvert.DeserializeObject<DataSet>(A);
                            Movie m = JsonConvert.DeserializeObject<Movie>(A);
                            result.Add(m);

                        } while (sr.ReadLine() != null);
                        //string s = sr.ReadToEnd();
                        return result;
                        //return s;
                    }
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string respStr = sr.ReadToEnd();
                        int statusCode = (int)response.StatusCode;

                        string errorMsh = $"Request ({Uri}) failed ({statusCode}) on, with error: {respStr}";
                        throw new WebException(errorMsh);
                    }
                }
            }
        }
        public static async Task<List<Movie>> getMoviesAsync()
        {
            List<Movie> movieList = new List<Movie>();
            for (int i = 1; i < 11; i++)
            {
                WebRequest request = WebRequest.Create("https://api.themoviedb.org/3/movie/popular?api_key=85a1114cc9bcee8c748abdaaade8169a&language=en-US&page=" + i);
                WebResponse response = await request.GetResponseAsync();
                Stream dataStream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(dataStream))
                {
                    while (sr.ReadLine()!=null)
                    {
                        movieList.Add(JsonConvert.DeserializeObject<Movie>(sr.ReadLine()));

                    }

                }
            }
            return movieList;
            
        }
        
        public MainPage()
		{
            Task<List<Movie>> task1=getMoviesAsync();
            List<Movie> m = task1.Result;
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"MoviesDB.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Movie>();
            if (db.Table<Movie>().Count()==0)
            {
                foreach (Movie item in m)
                {
                    db.Insert(item);
                }
            }
            moviesView.ItemsSource = db.Table<Movie>();
            
            InitializeComponent();
            
        }
	}
}
