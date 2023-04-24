using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Students.Client.Models;

namespace Students.Client.ApiServices
{
    public class StudentApiService : IStudentApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/api/students/");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var studentList = JsonConvert.DeserializeObject<List<Student>>(content);
            return studentList;
        }

        public async Task<IEnumerable<StudentStatus>> GetStudentStatuses()
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/api/studentStatus/");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var statuses = JsonConvert.DeserializeObject<List<StudentStatus>>(content);
            
            return statuses;
        }

        public async Task<Student?> GetStudent(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"/api/students/{id}");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var student= JsonConvert.DeserializeObject<Student>(content);
            return student;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "/api/students/");

            request.Content =
                new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            
            var createdStudent = JsonConvert.DeserializeObject<Student>(content);
            
            return createdStudent;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Put,
                $"/api/students/{student.StudentId}");

            request.Content =
                new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            
            var createdStudent = JsonConvert.DeserializeObject<Student>(content);
            
            return createdStudent;
        }

        public async Task DeleteStudent(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Delete,
                $"/api/students/{id}");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }
}
