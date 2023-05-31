using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPaymentMethod
    {
        public TblPaymentMethod()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public byte PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = null!;
        public bool? IsActive { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
