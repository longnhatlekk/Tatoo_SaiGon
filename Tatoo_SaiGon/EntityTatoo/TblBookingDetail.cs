using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblBookingDetail
{
    public int BookingDetailId { get; set; }

    public bool? Status { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public double? TotalPrice { get; set; }

    public DateTime? BookingDate { get; set; }

    public int? Toconfirm { get; set; }

    public int? BookingId { get; set; }

    public int? ServiceId { get; set; }

    public virtual TblBooking? Booking { get; set; }

    public virtual TblService? Service { get; set; }
}
