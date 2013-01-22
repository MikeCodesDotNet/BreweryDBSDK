
using System;
using NUnit.Framework;

using BreweryDBSDK;
using System.Collections;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Test_Breweries
    {
        private BreweryDBSDK.BreweryDBSDK db;
        
        #region "By ID"
        [Test]
        public void GetBreweryNameByID()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            BreweryDBSDK.Entity.Brewery brewery = db.GetBreweryById("P8gV9M");
            
            if (brewery.name == "16 Mile Brewing Company")
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("Incorrect name");
            }
        }

        [Test]
        public void SearchBreweriesByName()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            IDictionary<string, string> param = 
                new Dictionary<string, string>();
            
            param.Add("brewery", "5 Boroughs Brewery");
            
            BreweryDBSDK.Entity.Breweries breweries = db.SearchBreweries(param);
            
            foreach(BreweryDBSDK.Entity.Brewery b in breweries.breweries)
            {
                Console.WriteLine(b.name);
            }
            
            if(breweries.breweries.Count != 0)
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("No Breweries found");
            }
        }
           
        [Test]
        public void GetAllBeersBreweryHas()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            BreweryDBSDK.Entity.Brewery param = new BreweryDBSDK.Entity.Brewery();
            param.id = "d25euF";
            
            BreweryDBSDK.Entity.Beers beers = db.GetBeersByBrewery(param);
            
            foreach(BreweryDBSDK.Entity.Beer b in beers.beers)
            {
                Console.WriteLine(b.name);
            }
            
            if(beers.beers.Count != 0)
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("No beers found");
            }
        }
    
        [Test]
        public void GetBreweryImage()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            IDictionary<string, string> param = 
                new Dictionary<string, string>();
            
            param.Add("brewery", "5 Boroughs Brewery");
            
            BreweryDBSDK.Entity.Breweries breweries = db.SearchBreweries(param);
            
            foreach(BreweryDBSDK.Entity.Brewery b in breweries.breweries)
            {
                Console.WriteLine(b.name);
            }
            
            if(breweries.breweries[0].images.icon != null)
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("No Breweries found");
            }
        }

    }

#endregion


}
