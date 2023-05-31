using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblCompany
    {
        public TblCompany()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        public long CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;
        public byte? CountryId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TblCountry? Country { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
