using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblSubCategory
    {
        public TblSubCategory()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public short? CategoryId { get; set; }

        public virtual TblCategory? Category { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
