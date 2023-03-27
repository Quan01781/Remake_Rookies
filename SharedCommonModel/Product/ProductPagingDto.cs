using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Product
{
    public class ProductPagingDto
    {
        public int totalCount { get; set; }
        public List<ProductDto>? products { get; set; }
    }
}
