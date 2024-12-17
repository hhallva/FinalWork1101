using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Models;

public partial class ExamProduct
{
    public string ArticleNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public decimal Cost { get; set; }

    public byte? DiscountAmount { get; set; }

    public int QuantityInStock { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<ExamOrderProduct> ExamOrderProducts { get; set; } = new List<ExamOrderProduct>();
}
