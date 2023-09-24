using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblSchedule
{
    public int ScheduleId { get; set; }

    public DateTime? FreeTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Attendent { get; set; }

    public bool? Status { get; set; }

    public int? ArtistId { get; set; }

    public virtual TblArtist? Artist { get; set; }
}
