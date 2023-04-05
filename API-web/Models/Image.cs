using API_web.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_web.Models
{
    public class Image : Auditable
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public Product? Product { get; set; }
      
    }
}
