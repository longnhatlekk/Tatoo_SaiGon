using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblAddressStudio
{
    public int AddressId { get; set; }

    public string? Address { get; set; }

    public string? AddressDetail { get; set; }

    public string? Phonenumber { get; set; }

    public int? StudioId { get; set; }

    public virtual TblStudio? Studio { get; set; }
}
