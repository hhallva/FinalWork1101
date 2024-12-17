using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Models;

public partial class ExamOrderProduct
{
    public int OrderId { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public short Amount { get; set; }

    public virtual ExamOrder Order { get; set; } = null!;

    public virtual ExamProduct ProductArticleNumberNavigation { get; set; } = null!;
}
