namespace Capstone.Models
{
    public class Drink
    {
        public int restaurant_ID { get; set; }
        public int drink_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public bool isFrozen { get; set; }
    }
}
