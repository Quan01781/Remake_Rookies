using System.ComponentModel.DataAnnotations;

namespace API_web.Abstract
{
    public abstract class Auditable
    {
        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string? UpdateBy { get; set; }
    }
}
