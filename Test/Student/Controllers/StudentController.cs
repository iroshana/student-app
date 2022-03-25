using Microsoft.AspNetCore.Mvc;
using Student.Services;
using Student.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("create-student")]
        public async Task<IActionResult> CreateStudent(StudentViewModel studentViewModel)
        {
            try
            {                
                return Ok(await _studentService.CreateStudent(studentViewModel));
            }
            catch (Exception)
            {
                return BadRequest(500);
            }            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                return Ok(await _studentService.GetStudentById(id));
            }
            catch (Exception)
            {
                return BadRequest(500);
            }
            
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                return Ok(await _studentService.GetStudentList());
            }
            catch (Exception)
            {
                return BadRequest(500);
            }
        }
    }
}
