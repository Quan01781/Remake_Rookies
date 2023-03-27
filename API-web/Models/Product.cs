using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace API_web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } 
        public string Description { get; set; } 
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<CategoryProduct>? CategoryProduct { get; set; }
        public ICollection<Rating>? Ratings { get; set; } 
    }
}
