using Nest;

namespace Capstone.Models
{
    public class Review
    {
        public int Review_ID { get; set; }
        public int Reviewable_ID { get; set; }
        public int Rating { get; set; }
        public string ReviewerUsername { get; set; }
        public int Reviewer_ID { get; set; }
        public string ReviewText { get; set; }
    }
}
