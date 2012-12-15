using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreweryDBSDK.Entity
{
    public class Style
    {
        public long id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public decimal srmMax { get; set; }
        public decimal srmMin { get; set; }
        public decimal ibuMax { get; set; }
        public decimal ibuMin { get; set; }
        public decimal fgMin { get; set; }
        public decimal fgMax { get; set; }
        public DateTime createDate { get; set; }
        public long categoryId { get; set; }
        public decimal abvMax { get; set; }
        public decimal abvMin { get; set; }
        public Category category { get; set; }
    }
}
