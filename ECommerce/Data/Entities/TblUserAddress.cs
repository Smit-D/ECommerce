using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblUserAddress
    {
        public TblUserAddress()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public long UserAddressId { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public long UserId { get; set; }
        public byte CountryId { get; set; }
        public int CityId { get; set; }
        public byte? PostalCode { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblCity City { get; set; } = null!;
        public virtual TblCountry Country { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
