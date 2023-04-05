using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Abstract
{
    public class AuditableDto
    {
        public DateTime? Created_at { get; set; }
        public string? Created_by { get; set; }
        public DateTime? Updated_at { get; set; }
        public string? Updated_by { get; set; }
    }
}
