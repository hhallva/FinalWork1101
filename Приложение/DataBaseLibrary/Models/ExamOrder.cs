using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Models;

public partial class ExamOrder
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int PickupPointIndex { get; set; }

    public int PickupCode { get; set; }

    public virtual ICollection<ExamOrderProduct> ExamOrderProducts { get; set; } = new List<ExamOrderProduct>();

    public virtual ExamPickupPoint PickupPointIndexNavigation { get; set; } = null!;

    public virtual ExamUser? User { get; set; }
}
