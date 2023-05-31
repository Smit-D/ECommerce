using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblCarts = new HashSet<TblCart>();
            TblOrders = new HashSet<TblOrder>();
            TblProductMedia = new HashSet<TblProductMedium>();
            TblProductRatings = new HashSet<TblProductRating>();
            TblProductReviews = new HashSet<TblProductReview>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public string Sku { get; set; } = null!;
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public bool IsFree { get; set; }
        public short? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public long? CompanyId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TblCategory? Category { get; set; }
        public virtual TblCompany? Company { get; set; }
        public virtual TblSubCategory? SubCategory { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        public virtual ICollection<TblProductMedium> TblProductMedia { get; set; }
        public virtual ICollection<TblProductRating> TblProductRatings { get; set; }
        public virtual ICollection<TblProductReview> TblProductReviews { get; set; }
    }
}
