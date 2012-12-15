using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreweryDBSDK.Entity
{
    public class Category
    {
        public long id { get; set; }
        public DateTime createDate { get; set; }
        public String name { get; set; }
    }
}
