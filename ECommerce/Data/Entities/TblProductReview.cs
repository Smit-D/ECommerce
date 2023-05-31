using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblProductReview
    {
        public TblProductReview()
        {
            TblProductReviewMedia = new HashSet<TblProductReviewMedium>();
        }

        public long ProductReviewId { get; set; }
        public string Description { get; set; } = null!;
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TblProduct Product { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblProductReviewMedium> TblProductReviewMedia { get; set; }
    }
}
