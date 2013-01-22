using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreweryDBSDK.DTO
{
    internal class Breweries
    {
        public List<Entity.Brewery> data { get; set; }
        public int numberOfPages { get; set; }
        public int currentPage { get; set; }
    }
}

