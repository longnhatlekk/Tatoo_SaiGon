using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblStudioStaff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public int? StudioId { get; set; }

    public int? UserId { get; set; }

    public virtual TblStudio? Studio { get; set; }

    public virtual ICollection<TblFeedbackSystem> TblFeedbackSystems { get; set; } = new List<TblFeedbackSystem>();

    public virtual TblUser? User { get; set; }
}
