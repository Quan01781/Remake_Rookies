using API_web.Abstract;
using System.ComponentModel.DataAnnotations;

namespace API_web.Models
{
    public class Image : Auditable
    {
        [Key]
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public string? Url { get; set; }
        public int? DisplayOrder { get; set; }
        public Product? Product { get; set; }
      
    }
}
