using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblBooking
{
    public int BookingId { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateBooking { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Note { get; set; }

    public double? TotalPrice { get; set; }

    public int? MemberId { get; set; }

    public int? PaymentId { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual TblPayment? Payment { get; set; }

    public virtual ICollection<TblBookingDetail> TblBookingDetails { get; set; } = new List<TblBookingDetail>();
}
