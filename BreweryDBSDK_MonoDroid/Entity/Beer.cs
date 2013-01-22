using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreweryDBSDK.Entity
{
    public class Beer
    {
        public string id { get; set; }
        public decimal abv { get; set; }
        public string name { get; set; }
        public long styleId { get; set; }
        public long glasswareId { get; set; }
        public long availableId { get; set; }
        public string isOrganic { get; set; }
        public string status { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public Glass glass { get; set; }
        public Style style { get; set; }
        public Available available { get; set; }
    }
}
