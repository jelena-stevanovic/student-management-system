using Students.Client.Models;

namespace Students.Client.ApiServices
{
    public interface IStudentApiService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<StudentStatus>> GetStudentStatuses();
        Task<Student?> GetStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
