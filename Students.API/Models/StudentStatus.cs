using System;
using System.Collections.Generic;

namespace Students.API.Models;

public partial class StudentStatus
{
    public long StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
