using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Students.Client.ApiServices;
using Students.Client.Models;

namespace Students.Client.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentApiService _studentApiService;

        public StudentsController(IStudentApiService studentApiService)
        {
            _studentApiService = studentApiService ?? throw new ArgumentNullException(nameof(studentApiService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Index()
        {
            return (await _studentApiService.GetStudents()).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Details(int id)
        {
            return (await _studentApiService.GetStudent(id));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _studentApiService.DeleteStudent(id);
            return Ok();
        }
        
        [HttpGet("statuses")]
        public async Task<ActionResult<IEnumerable<StudentStatus>>> Statuses()
        {
            return (await _studentApiService.GetStudentStatuses()).ToList();
        }
        
        [HttpPost]
        public async Task<ActionResult<Student>> Create([Bind("StudentId,FirstName,LastName,EnrollmentYear,StatusId,StudentNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                var createdStudent = await _studentApiService.CreateStudent(student);
                return createdStudent;
            }
            
            return BadRequest();
        }
        
        [HttpPut]
        public async Task<ActionResult<Student>> Update([Bind("StudentId,FirstName,LastName,EnrollmentYear,StatusId,StudentNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                var createdStudent = await _studentApiService.UpdateStudent(student);
                return createdStudent;
            }
            
            return BadRequest();
        }
        
    }
}
