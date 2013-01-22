
using System;
using NUnit.Framework;

using BreweryDBSDK;
using System.Collections;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Test_Beers
    {
        private BreweryDBSDK.BreweryDBSDK db;

        #region "By ID"
        [Test]
        public void GetBeerNameByID()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);

            BreweryDBSDK.Entity.Beer beer = db.GetBeerById("AGgBSb");

            if (beer.name == "Leffe Brune")
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("Incorrect name");
            }
        }
       
        [Test]
        public void GetBeerAbvByID()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            BreweryDBSDK.Entity.Beer beer = db.GetBeerById("AGgBSb");
            
            if (beer.abv == Convert.ToDecimal(6.5))
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("Incorrect Abv");
            }
        }
    
        [Test]
        public void GetBeerStyleByID()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            BreweryDBSDK.Entity.Beer beer = db.GetBeerById("AGgBSb");

            BreweryDBSDK.Entity.Style style = new BreweryDBSDK.Entity.Style();
            style.name = "Belgian-Style Dark Strong Ale";

            if (beer.style.name == style.name)
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("Incorrect Style");
            }
        }
    
        [Test]
        public void GetBeerAvailablityByID()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);
            
            BreweryDBSDK.Entity.Beer beer = db.GetBeerById("AGgBSb");

            BreweryDBSDK.Entity.Available av = new BreweryDBSDK.Entity.Available();
            av.name = "Year Round";

            if (beer.available.name == av.name)
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("Incorrect Style");
            }
        }
        #endregion

        [Test]
        public void GetBeerByUPC()
        {
            db = new BreweryDBSDK.BreweryDBSDK(Application.Key);

            var param = "786150000304";

            BreweryDBSDK.Entity.Beers beers = db.GetBeerByUPC(param);

            foreach(BreweryDBSDK.Entity.Beer b in beers.beers)
            {
                Console.WriteLine(b.name);
            }

            if(beers.beers[0].name == "Leffe Blonde")
            {
                Assert.True(true);
            } else
            {
                Assert.Fail("No beers found");
            }
        }



    }
}
