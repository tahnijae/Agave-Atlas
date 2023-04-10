using System.Collections.Generic;

namespace Capstone.Models
{
    public class Restaurant
    {
        public int restaurant_ID { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
