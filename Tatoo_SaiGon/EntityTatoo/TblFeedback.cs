using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblFeedback
{
    public int FeedbackId { get; set; }

    public string? FeedbackDetail { get; set; }

    public bool? IsFeedback { get; set; }

    public int? MemberId { get; set; }

    public int? ServiceId { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual TblService? Service { get; set; }

    public virtual ICollection<TblImageFeedback> TblImageFeedbacks { get; set; } = new List<TblImageFeedback>();
}
