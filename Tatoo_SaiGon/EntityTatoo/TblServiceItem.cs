using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblServiceItem
{
    public string ServiceItemId { get; set; } = null!;

    public string? ServiceName { get; set; }

    public virtual ICollection<TblService> TblServices { get; set; } = new List<TblService>();
}
