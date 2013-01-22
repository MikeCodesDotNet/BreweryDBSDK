using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreweryDBSDK.Entity
{
    public class Breweries
    {
        public List<Brewery> breweries { get; set; }
        public int numberOfPages { get; set; }
        public int currentPage { get; set; }
    }
}

