using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblSalary
{
    public int SalaryId { get; set; }

    public double? SalaryAmout { get; set; }

    public string? PaymentMethod { get; set; }

    public double? BonusMoney { get; set; }

    public double? Deductions { get; set; }

    public bool? Status { get; set; }

    public DateTime? SalaryDate { get; set; }

    public int? ArtistId { get; set; }

    public virtual TblArtist? Artist { get; set; }
}
