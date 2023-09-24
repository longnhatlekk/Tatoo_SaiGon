using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? Status { get; set; }

    public string? Dob { get; set; }

    public DateTime? CreateUser { get; set; }

    public string? Image { get; set; }

    public string? RoleId { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual ICollection<TblMember> TblMembers { get; set; } = new List<TblMember>();

    public virtual ICollection<TblStudioStaff> TblStudioStaffs { get; set; } = new List<TblStudioStaff>();

    public virtual ICollection<TblSystemStaff> TblSystemStaffs { get; set; } = new List<TblSystemStaff>();
}
