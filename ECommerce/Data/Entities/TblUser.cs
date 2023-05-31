using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCarts = new HashSet<TblCart>();
            TblOrders = new HashSet<TblOrder>();
            TblProductRatings = new HashSet<TblProductRating>();
            TblProductReviews = new HashSet<TblProductReview>();
            TblUserAddresses = new HashSet<TblUserAddress>();
        }

        public long UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool? IsActive { get; set; }
        public byte CountryId { get; set; }
        public int CityId { get; set; }
        public string? ProfileImg { get; set; }
        public byte? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TblCity City { get; set; } = null!;
        public virtual TblCountry Country { get; set; } = null!;
        public virtual TblRole? Role { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        public virtual ICollection<TblProductRating> TblProductRatings { get; set; }
        public virtual ICollection<TblProductReview> TblProductReviews { get; set; }
        public virtual ICollection<TblUserAddress> TblUserAddresses { get; set; }
    }
}
