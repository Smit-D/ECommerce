using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblCities = new HashSet<TblCity>();
            TblCompanies = new HashSet<TblCompany>();
            TblUserAddresses = new HashSet<TblUserAddress>();
            TblUsers = new HashSet<TblUser>();
        }

        public byte CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public bool? IsActive { get; set; }

        public virtual ICollection<TblCity> TblCities { get; set; }
        public virtual ICollection<TblCompany> TblCompanies { get; set; }
        public virtual ICollection<TblUserAddress> TblUserAddresses { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
