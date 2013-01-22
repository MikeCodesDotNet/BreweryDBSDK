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

        public Beer GetBeer(string id)
        {
            var client = GetClient();

            var request = new RestRequest();
            request.Resource = string.Format("beer/{0}?key={1}",id,_key);
            var response2 = client.Execute<DTO.Beer>(request);

            return response2.Data.Data;
        }   

        private static RestClient GetClient()
        {
            var client = new RestClient();
            client.BaseUrl = _endPoint;
            return client;
        }

        public Beers SearchBeers(IDictionary<string,string> parameters)
        {
            var client = GetClient();
            var request = new RestRequest();
            request.Resource = AddParametersToString(parameters, string.Format("beers?key={0}", _key));
            var response2 = client.Execute<DTO.Beers>(request);

            return new Beers{currentPage = response2.Data.currentPage, beers = response2.Data.data, numberOfPages = response2.Data.numberOfPages};
        }

        private static String AddParametersToString(IDictionary<string, string> parameters, string call)
        {
            foreach (var search in parameters)
            {
                call = string.Format("{0}&{1}={2}", call, search.Key, search.Value);
            }
            return call;
        }
    }
}
