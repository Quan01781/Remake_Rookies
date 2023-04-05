using API_web.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_web.Models
{
    public class Category : Auditable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ICollection<CategoryProduct>? CategoryProduct { get; set; }       
    }
}
