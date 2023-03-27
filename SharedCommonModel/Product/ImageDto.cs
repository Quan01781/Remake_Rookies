using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Product
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public string? Url { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
