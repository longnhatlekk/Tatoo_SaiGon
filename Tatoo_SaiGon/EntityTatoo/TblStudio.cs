using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblStudio
{
    public int StudioId { get; set; }

    public string? StudioName { get; set; }

    public bool? IsActive { get; set; }

    public int? ServiceId { get; set; }

    public int? ManagerId { get; set; }

    public virtual TblManagerStudio? Manager { get; set; }

    public virtual TblService? Service { get; set; }

    public virtual ICollection<TblAddressStudio> TblAddressStudios { get; set; } = new List<TblAddressStudio>();

    public virtual ICollection<TblStudioStaff> TblStudioStaffs { get; set; } = new List<TblStudioStaff>();
}
