using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProducts = new HashSet<TblProduct>();
            TblSubCategories = new HashSet<TblSubCategory>();
        }

        public short CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool? IsActive { get; set; }

        public virtual ICollection<TblProduct> TblProducts { get; set; }
        public virtual ICollection<TblSubCategory> TblSubCategories { get; set; }
    }
}
