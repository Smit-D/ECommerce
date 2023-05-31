using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public byte RoleId { get; set; }
        public string Role { get; set; } = null!;
        public bool? IsActive { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
