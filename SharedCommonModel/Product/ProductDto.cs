using SharedCommonModel.Category;
using SharedCommonModel.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SharedCommonModel.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<ImageDto>? Images { get; set; }
        public List<CategoryDto>? Categories { get; set; }
        public List<RatingDto>? Ratings { get; set; }
    }
}
