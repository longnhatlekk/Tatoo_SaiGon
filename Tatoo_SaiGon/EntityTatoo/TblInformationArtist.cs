using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblInformationArtist
{
    public int InforId { get; set; }

    public DateTime? Birthday { get; set; }

    public string? CurrentAddress { get; set; }

    public string? Accommodation { get; set; }

    public string? Phonenumber { get; set; }

    public string? Description { get; set; }

    public int? ArtistId { get; set; }

    public virtual TblArtist? Artist { get; set; }

    public virtual ICollection<TblCertificate> TblCertificates { get; set; } = new List<TblCertificate>();
}
