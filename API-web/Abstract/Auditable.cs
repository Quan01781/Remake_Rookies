using System.ComponentModel.DataAnnotations;

namespace API_web.Abstract
{
    public abstract class Auditable
    {
        public DateTime? Created_at { get; set; }

        [MaxLength(256)]
        public string? Created_by { get; set; }
        public DateTime? Updated_at { get; set; }
        [MaxLength(256)]
        public string? Updated_by { get; set; }
    }
}
