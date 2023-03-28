using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommonModel.Abstract
{
    public class AuditableDto
    {
        public DateTime? Create_Date { get; set; }
        public string? Create_By { get; set; }
        public DateTime? Update_Date { get; set; }
        public string? Update_By { get; set; }
    }
}
