using System.ComponentModel.DataAnnotations;

namespace API_web.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string? Message { get; set; } 
        public DateTime Created_at { get; set; }      
        public Product Product { get; set; } = new Product();
    }
}
