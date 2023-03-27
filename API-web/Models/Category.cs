using API_web.Abstract;
using System.ComponentModel.DataAnnotations;

namespace API_web.Models
{
    public class Category : Auditable
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryProduct>? CategoryProduct { get; set; }       
    }
}
