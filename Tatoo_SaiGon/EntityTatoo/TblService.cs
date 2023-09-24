using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblService
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public double? DiscountPersen { get; set; }

    public double? SoldPrice { get; set; }

    public bool? IsActive { get; set; }

    public int? ArtistId { get; set; }

    public string? ServiceItemId { get; set; }

    public virtual TblArtist? Artist { get; set; }

    public virtual TblServiceItem? ServiceItem { get; set; }

    public virtual ICollection<TblBookingDetail> TblBookingDetails { get; set; } = new List<TblBookingDetail>();

    public virtual ICollection<TblFeedback> TblFeedbacks { get; set; } = new List<TblFeedback>();

    public virtual ICollection<TblImageService> TblImageServices { get; set; } = new List<TblImageService>();

    public virtual ICollection<TblReport> TblReports { get; set; } = new List<TblReport>();

    public virtual ICollection<TblStudio> TblStudios { get; set; } = new List<TblStudio>();
}
