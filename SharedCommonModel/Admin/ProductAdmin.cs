using SharedCommonModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Admin
{
    public class ProductAdmin : AuditableDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public ICollection<CategoryAdmin>? Categories { get; set; }
        public ICollection<ImageAdmin>? Images { get; set; }

    }
}
