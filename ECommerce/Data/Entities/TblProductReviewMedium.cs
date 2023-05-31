using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblProductReviewMedium
    {
        public long ReviewMediaId { get; set; }
        public string? MeidaName { get; set; }
        public string MediaUrl { get; set; } = null!;
        public string MediaType { get; set; } = null!;
        public long ProductReviewId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TblProductReview ProductReview { get; set; } = null!;
    }
}
