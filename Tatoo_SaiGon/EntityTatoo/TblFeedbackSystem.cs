using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblFeedbackSystem
{
    public int FeedbackId { get; set; }

    public string? FeedbackDetail { get; set; }

    public bool? Status { get; set; }

    public DateTime? FeedbackDate { get; set; }

    public int? StaffId { get; set; }

    public int? ManagerId { get; set; }

    public virtual TblManagerStudio? Manager { get; set; }

    public virtual TblStudioStaff? Staff { get; set; }
}
