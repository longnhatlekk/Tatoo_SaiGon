using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblImageService
{
    public int ImageId { get; set; }

    public string? Image { get; set; }

    public int? ServiceId { get; set; }

    public virtual TblService? Service { get; set; }
}
