using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblArtist
{
    public int ArtistId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblInformationArtist> TblInformationArtists { get; set; } = new List<TblInformationArtist>();

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();

    public virtual ICollection<TblSalary> TblSalaries { get; set; } = new List<TblSalary>();

    public virtual ICollection<TblSchedule> TblSchedules { get; set; } = new List<TblSchedule>();

    public virtual ICollection<TblService> TblServices { get; set; } = new List<TblService>();
}
