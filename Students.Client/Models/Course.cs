namespace Students.Client.Models
{
    public class Course
    {
        public long CourseId { get; set; }
        public string? CourseName { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
