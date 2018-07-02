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

namespace TestMovieDB
{
	public partial class MainPage : ContentPage
	{
        public static string JsonFromUriAsync(string Uri)
        {
            var req = WebRequest.CreateHttp(Uri);

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
                        string s = sr.ReadToEnd();
                        return s;
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
                        return errorMsh;
                    }
                }
            }
        }
        public MainPage()
		{
			InitializeComponent();
            var items = new List<MovieEntry>();
            
            string jsonString = JsonFromUriAsync("http://files.tmdb.org/p/exports/movie_ids_06_01_2018.json.gz");
            dynamic json = new JObject(jsonString);
            var items=JsonConvert.DeserializeObject<Movies>


                moviesView.ItemsSource = items;
		}
	}
}
