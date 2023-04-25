using System.Text;
using Newtonsoft.Json;
using Students.Client.Models;

namespace Students.Client.ApiServices
{
    public class CourseApiService : ICourseApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CourseApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/api/courses/");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var courseList = JsonConvert.DeserializeObject<List<Course>>(content);
            return courseList;
        }

        public async Task<Course?> GetCourse(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"/api/courses/{id}");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var course = JsonConvert.DeserializeObject<Course>(content);
            return course;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "/api/courses/");

            request.Content =
                new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var createdCourse = JsonConvert.DeserializeObject<Course>(content);

            return createdCourse;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Put,
                $"/api/courses/{course.CourseId}");

            request.Content =
                new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var createdCourse = JsonConvert.DeserializeObject<Course>(content);

            return createdCourse;
        }

        public async Task DeleteCourse(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("StudentAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Delete,
                $"/api/courses/{id}");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }
}
