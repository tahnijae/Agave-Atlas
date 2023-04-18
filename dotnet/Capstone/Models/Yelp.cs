using Azure;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Capstone.Models
{
    public class Yelp
    {
        public string Name { get; set; }
        public string YelpId { get; set; }
        public string Phone { get; set; }
        public string DisplayPhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip_code { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public bool Is_closed { get; set; }
        public string Url { get; set; }
        //public List<string> Categories { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class NameAndZip
    {
        public string Zipcode { get; set; }
        public string Name { get; set; }
    }
}