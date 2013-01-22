using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreweryDBSDK.Entity
{
    public class Beers
    {
        public List<Beer> beers { get; set; }
        public int numberOfPages { get; set; }
        public int currentPage { get; set; }
    }
}
