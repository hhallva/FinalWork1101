using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Models;

public partial class ExamPickupPoint
{
    public int PickupPointIndex { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Building { get; set; } = null!;

    public virtual ICollection<ExamOrder> ExamOrders { get; set; } = new List<ExamOrder>();
}
