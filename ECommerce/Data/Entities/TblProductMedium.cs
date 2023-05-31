using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblProductMedium
    {
        public long MediaId { get; set; }
        public string? MeidaName { get; set; }
        public string MediaUrl { get; set; } = null!;
        public string MediaType { get; set; } = null!;
        public bool? IsDefault { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TblProduct Product { get; set; } = null!;
    }
}
