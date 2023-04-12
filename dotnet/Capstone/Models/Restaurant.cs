using System.Collections.Generic;

namespace Capstone.Models
{
    public class Restaurant
    {
        public int Restaurant_ID { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        //public List<Drink> Drinks { get; set; } - Took out for now since getting a restaurant from the database doesn't include

    }
    public class NewRestaurantInput
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }
    }
}
