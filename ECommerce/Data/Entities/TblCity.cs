using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblUserAddresses = new HashSet<TblUserAddress>();
            TblUsers = new HashSet<TblUser>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public byte? CountryId { get; set; }

        public virtual TblCountry? Country { get; set; }
        public virtual ICollection<TblUserAddress> TblUserAddresses { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
