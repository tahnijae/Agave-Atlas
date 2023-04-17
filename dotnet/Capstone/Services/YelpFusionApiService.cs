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
using Newtonsoft.Json;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.Services
{
    public class YelpFusionApiService 
    {
        private string apiKey = File.ReadAllText("YelpApiKey.txt");
        public string apiUrl = "https://api.yelp.com/v3/";
        private string connectionString;

        public YelpFusionApiService(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public Yelp GetRestaurantInfo()
        {
            RestClient client = new RestClient(apiUrl);
            //RestRequest request = new RestRequest("businesses/search?location=44113&term=Barrio&sort_by=best_match&limit=5");
            RestRequest request = new RestRequest("businesses/search?location=44113&term=Barrio&sort_by=best_match&limit=5");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", apiKey);
            RestResponse response = client.Execute(request);


            string content = response.Content;

            // Deserialize the JSON data into a C# object
            var result = JsonConvert.DeserializeObject<dynamic>(content);
            List<Yelp> businesses = new List<Yelp>();
            foreach (var business in result.businesses)
            {
                Yelp yelp = new Yelp()
                {
                    Name = business.name,
                    YelpId = business.id,
                    Address = business.location.address1,
                    City = business.location.city,
                    State = business.location.state,
                    Country = business.location.country,
                    Zip_code = business.location.zip_code,
                    Phone = business.phone,
                    Rating = business.rating,
                    ReviewCount = business.review_count,
                    Is_closed = business.is_closed,
                    Url = business.url,
                    Latitude = business.coordinates.latitude,
                    Longitude = business.coordinates.longitude
                };
                businesses.Add(yelp);
            }
            return businesses[0];
        }

    }
}
