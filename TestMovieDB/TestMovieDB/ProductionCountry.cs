using System;
using System.Collections.Generic;
using System.Text;

namespace TestMovieDB
{
    public class ProductionCountry
    {
        public ProductionCountry()
        {
        }

        public ProductionCountry(string iso_3166_1, string name)
        {
            this.iso_3166_1 = iso_3166_1;
            this.name = name;
        }

        public string iso_3166_1 { get; private set; }
        public string name { get; private set; }
    }
}
