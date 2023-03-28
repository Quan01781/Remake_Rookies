using API_web.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace API_web.Models
{
    public class Product : Auditable
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; } 
        public string? Description { get; set; } 
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<CategoryProduct>? CategoryProduct { get; set; }
        public ICollection<Rating>? Ratings { get; set; } 
    }
}
