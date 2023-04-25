using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Students.Client.ApiServices;
using Students.Client.Models;

namespace Students.Client.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseApiService _courseApiService;

        public CoursesController(ICourseApiService courseApiService)
        {
            _courseApiService = courseApiService ?? throw new ArgumentNullException(nameof(courseApiService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> Index()
        {
            return (await _courseApiService.GetCourses()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Details(int id)
        {
            return await _courseApiService.GetCourse(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _courseApiService.DeleteCourse(id);
            return Ok();
        }

        public async Task<ActionResult<Course>> Create([Bind("CourseId,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                var createdCourse = await _courseApiService.CreateCourse(course);
                return createdCourse;
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Course>> Update([Bind("CourseId,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                var createdCourse = await _courseApiService.UpdateCourse(course);
                return createdCourse;
            }

            return BadRequest();
        }
    }
}
