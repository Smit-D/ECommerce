using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblSupplier
    {
        public TblSupplier()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public long SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
