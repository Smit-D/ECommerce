using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblOrder
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public byte? Quantity { get; set; }
        public decimal? TotalAmountPaid { get; set; }
        public byte PaymentMethodId { get; set; }
        public long UserAddressId { get; set; }
        public long SupplierId { get; set; }
        public DateTime? OrderedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        public virtual TblPaymentMethod PaymentMethod { get; set; } = null!;
        public virtual TblProduct Product { get; set; } = null!;
        public virtual TblSupplier Supplier { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual TblUserAddress UserAddress { get; set; } = null!;
    }
}
