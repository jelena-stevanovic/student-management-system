using System;
using System.Collections.Generic;

namespace Students.API.Models;

public partial class StudentCourse
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public long StudentId { get; set; }

    public virtual Course? Course { get; set; } = null!;

    public virtual Student? Student { get; set; } = null!;
}
