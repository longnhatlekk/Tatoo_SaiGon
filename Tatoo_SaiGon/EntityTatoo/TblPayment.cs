using System;
using System.Collections.Generic;

namespace Tatoo_SaiGon.EntityTatoo;

public partial class TblPayment
{
    public int PaymentId { get; set; }

    public DateTime? PaymentBooking { get; set; }

    public string? Method { get; set; }

    public double? Amount { get; set; }

    public bool? Status { get; set; }

    public int? MemberId { get; set; }

    public virtual TblMember? Member { get; set; }

    public virtual ICollection<TblBooking> TblBookings { get; set; } = new List<TblBooking>();
}
