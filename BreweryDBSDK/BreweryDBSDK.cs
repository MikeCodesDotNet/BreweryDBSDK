using RestSharp;
using UntappdSDK.Entity;

namespace UntappdSDK
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
            var client = new RestClient();
            client.BaseUrl = _endPoint;
            
            var request = new RestRequest();
            request.Resource = string.Format("beer/{0}?key={1}",id,_key);

            IRestResponse response = client.Execute(request);

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            var response2 = client.Execute<DTO.Beer>(request);

            return response2.Data.Data;
        }
    }
}
