
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
            db = new BreweryDBSDK.BreweryDBSDK("716ab38546fdfc49d75964861f413b6f");
            
            BreweryDBSDK.Entity.Brewery brewery = db.GetBrewery("P8gV9M");
            
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
           
        //Seems to be a problem with the API stopping this from working....
        [Test]
        public void GetAllBeersBreweryHas()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            BreweryDBSDK.Entity.Brewery param = new BreweryDBSDK.Entity.Brewery();
            param.id = "opTwlP";
            
            BreweryDBSDK.Entity.Beers beers = db.GetBeers(param);
            
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
    
    }

#endregion


}
