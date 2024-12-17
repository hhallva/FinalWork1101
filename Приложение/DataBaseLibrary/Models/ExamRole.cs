using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Models;

public partial class ExamRole
{
    public byte RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ExamUser> ExamUsers { get; set; } = new List<ExamUser>();
}
