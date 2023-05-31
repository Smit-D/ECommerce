using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblProductSupplierMapping
    {
        public long ProductId { get; set; }
        public long SupplierId { get; set; }
        public int? AvailableStocks { get; set; }
    }
}
