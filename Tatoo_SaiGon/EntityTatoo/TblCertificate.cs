using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblCertificate
{
    public int CerId { get; set; }

    public string? Certificate { get; set; }

    public int? InforId { get; set; }

    public virtual TblInformationArtist? Infor { get; set; }
}
