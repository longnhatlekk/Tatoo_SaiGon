using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblJob
{
    public int JobId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? AppointmentTime { get; set; }

    public bool? Status { get; set; }

    public int? ArtistId { get; set; }

    public virtual TblArtist? Artist { get; set; }
}
