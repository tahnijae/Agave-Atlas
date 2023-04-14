using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Http;
using RestSharp.Authenticators;
using System.Threading;
using System.IO;
using Capstone.Services;
using System;
using Nest;

namespace Capstone.Services
{
    public class YelpFusionApiService 
    {
        private string apiKey = File.ReadAllText("ApiKey.txt");
        public string apiUrl = "https://api.yelp.com/v3/";

        //RestClient client = new RestClient("https://api.yelp.com/v3/businesses/search?location=44113&term=Barrio&sort_by=best_match&limit=20");
        
        
        //RestRequest request = new RestRequest(Method.GET);
        //request.AddHeader("accept", "application/json");
        //request.AddHeader("Authorization", apiKey);
        //IRestResponse response = client.Execute(request);

        public RestResponse GetRestaurantInfo()
        {
            //var options = new RestClientOptions("https://api.twitter.com/1.1")
            //{
            //    Authenticator = new HttpBasicAuthenticator("username", "password")
            //};
            //var client = new RestClient(apiUrl);
            //var request = new RestRequest("businesses/search?location=44113&term=Barrio&sort_by=best_match&limit=20");
            //// The cancellation token comes from the caller. You can still make a call without it.
            //var response = client.Get(request);


            RestClient client = new RestClient("https://api.yelp.com/v3/businesses/search?location=44113&term=Barrio&sort_by=best_match&limit=20");
            RestRequest request = new RestRequest();
            //request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + apiKey);
            RestResponse response = client.Execute(request);
            

            return response;
        }

    }
}
