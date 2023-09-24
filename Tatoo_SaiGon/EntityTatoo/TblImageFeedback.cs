using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblImageFeedback
{
    public int ImageId { get; set; }

    public string? Image { get; set; }

    public int? FeedbackId { get; set; }

    public virtual TblFeedback? Feedback { get; set; }
}
