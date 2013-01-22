using System;
using System.Collections.Generic;
using RestSharp;
using BreweryDBSDK.Entity;

namespace BreweryDBSDK
{
    public class BreweryDBSDK
    {
        private string _key { get; set; }
        private const string _endPoint = "http://api.brewerydb.com/v2";
        public BreweryDBSDK(string apiKey)
        {
            _key = apiKey;
        }

        #region "Beers"
        /// <summary>
        /// Get a beer by its ID from the BreweryDB.
        /// </summary>
        /// <returns>
        /// A beer object.
        /// </returns>
        /// <param name='id'>
        /// Identifier.
        /// </param>
        public Beer GetBeerById(string id)
        {
            var client = GetClient();
            
            var request = new RestRequest();
            request.Resource = string.Format("beer/{0}?key={1}",id,_key);
            
            var response2 = client.Execute<DTO.Beer>(request);
            
            return response2.Data.Data;
        }   

        /// <summary>
        /// Searchs the breweryDB database using a barcode unique product code.
        /// </summary>
        /// <returns>
        /// A list of beer objects
        /// </returns>
        /// <param name='upc'>
        /// Upc.
        /// </param>
        public Beers GetBeerByUPC(string upc)
        {
            var client = GetClient();
            
            var request = new RestRequest();
            request.Resource = string.Format("search/upc?code={0}&key={1}", upc, _key);
            
            var response2 = client.Execute<DTO.Beers>(request);
            
            return new Beers {currentPage = response2.Data.currentPage, beers = response2.Data.data, numberOfPages = response2.Data.numberOfPages};
        }

        /// <summary>
        /// Get a list of beers from BreweryDB by the manufacturer.
        /// </summary>
        /// <returns>
        /// A list of beers
        /// </returns>
        /// <param name='brewery'>
        /// Brewery object. (must have valid ID).
        /// </param>
        public Beers GetBeersByBrewery(Brewery brewery)
        {
            var client = GetClient();
            
            var request = new RestRequest();
            request.Resource = string.Format("brewery/{0}/beers?key={1}",brewery.id,_key);
            
            var response2 = client.Execute<DTO.Beers>(request);
            
            return new Beers {currentPage = response2.Data.currentPage, beers = response2.Data.data, numberOfPages = response2.Data.numberOfPages};
        }

        /// <summary>
        /// Searchs the BreweryDB database using the name of a beer.
        /// </summary>
        /// <returns>
        /// A list of beers
        /// </returns>
        /// <param name='parameters'>
        /// The search type ('beers') and search term ('name of beer')
        /// </param>
        public Beers GetBeerByName(string name)
        {
            var client = GetClient();
            var request = new RestRequest();
            request.Resource = string.Format("search?q={0}&type=beer&key={1}",name, _key);
            var response2 = client.Execute<DTO.Beers>(request);
            
            return new Beers{currentPage = response2.Data.currentPage, beers = response2.Data.data, numberOfPages = response2.Data.numberOfPages};
        }

        /// <summary>
        /// Gets all the variations of this beer
        /// </summary>
        /// <returns>
        /// A list of beers
        /// </returns>
        /// <param name='beer'>
        /// Beer.
        /// </param>
        public Beers GetBeerVariations(Beer beer)
        {
            var client = GetClient();
            var request = new RestRequest();
            request.Resource = string.Format("beer/{0}/variations?key={1}",beer.id, _key);
            var response2 = client.Execute<DTO.Beers>(request);
            
            return new Beers{currentPage = response2.Data.currentPage, beers = response2.Data.data, numberOfPages = response2.Data.numberOfPages};
        }

        #endregion
       
        /// <summary>
        /// Gets brewery data from BreweryDB from its unqiue ID
        /// </summary>
        /// <returns>
        /// A brewery object
        /// </returns>
        /// <param name='id'>
        /// Identifier.
        /// </param>
        public Brewery GetBreweryById(string id)
        {
            var client = GetClient();
            
            var request = new RestRequest();
            request.Resource = string.Format("brewery/{0}?key={1}",id,_key);
            
            var response2 = client.Execute<DTO.Brewery>(request);
            
            return response2.Data.Data;
        }

        /// <summary>
        /// The for a brewery by name.
        /// </summary>
        /// <returns>
        /// A list of breweries 
        /// </returns>
        /// <param name='parameters'>
        /// Parameters.
        /// </param>
        public Breweries SearchBreweries(IDictionary<string, string> parameters)
        {
            var client = GetClient();
            var request = new RestRequest();
            request.Resource = AddParametersToString(parameters, string.Format("{0}", _key));
            var response2 = client.Execute<DTO.Breweries>(request);
            
            return new Breweries{currentPage = response2.Data.currentPage, breweries = response2.Data.data, numberOfPages = response2.Data.numberOfPages};
        }
        
        //------------------------------------------------------------------------------------------------------------------------------
        private static RestClient GetClient()
        {
            var client = new RestClient();
            client.BaseUrl = _endPoint;
            return client;
        }
        
        private String AddParametersToString(IDictionary<string, string> parameters, string call)
        {
            foreach (var search in parameters)
            {
                call = String.Format("search?q={0}&type={1}&key={2}", search.Value, search.Key, _key);
            }
            return call;
        }
    }
}
