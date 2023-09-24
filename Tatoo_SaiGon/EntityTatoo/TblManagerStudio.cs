using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblManagerStudio
{
    public int ManagerId { get; set; }

    public string? ManagementName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? StaffId { get; set; }

    public virtual TblSystemStaff? Staff { get; set; }

    public virtual ICollection<TblFeedbackSystem> TblFeedbackSystems { get; set; } = new List<TblFeedbackSystem>();

    public virtual ICollection<TblStudio> TblStudios { get; set; } = new List<TblStudio>();
}
