namespace Students.Client.Models;

public class Student
{
    public long StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? EnrollmentYear { get; set; }
    
    public string? StudentNumber { get; set; }
    
    public int? StatusId { get; set; }
    
    public StudentStatus? Status { get; set; }
    public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();

}
