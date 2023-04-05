using SharedCommonModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Admin
{
    public class CategoryAdmin : AuditableDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
