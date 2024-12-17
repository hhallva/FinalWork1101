using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Models;

public partial class ExamUser
{
    public int UserId { get; set; }

    public byte RoleId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<ExamOrder> ExamOrders { get; set; } = new List<ExamOrder>();

    public virtual ExamRole Role { get; set; } = null!;
}
