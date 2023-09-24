using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblJobApplication
{
    public int JobId { get; set; }

    public string? Filejob { get; set; }

    public int? MemberId { get; set; }

    public virtual TblMember? Member { get; set; }
}
