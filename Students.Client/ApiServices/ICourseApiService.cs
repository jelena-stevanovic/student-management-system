using Students.Client.Models;

namespace Students.Client.ApiServices
{
    public interface ICourseApiService
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourse(int id);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task DeleteCourse(int id);

    }
}
