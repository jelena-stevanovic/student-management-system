using System;
using System.Collections.Generic;

namespace Students.API.Models;

public partial class Student
{
    public long StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? EnrollmentYear { get; set; }

    public long? StatusId { get; set; }

    public string? StudentNumber { get; set; }

    public virtual StudentStatus? Status { get; set; }
}
