using SharedCommonModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Rating
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string? Message { get; set; }
        public int ProductId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
