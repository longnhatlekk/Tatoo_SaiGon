using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblReport
{
    public int ReportId { get; set; }

    public string? ReportDetail { get; set; }

    public bool? IsReport { get; set; }

    public DateTime? CreateReport { get; set; }

    public int? MemberId { get; set; }

    public int? ServiceId { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual TblService? Service { get; set; }
}
