using AutoMapper;
using CleanArch.Application.Services;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<StudentViewModel>> Get()
        {
            // This maps the list of students to the DTO / View Model
            var students = _mapper.Map<IEnumerable<StudentViewModel>>(await _studentService.GetStudents());
            if (students == null)
                return NotFound();
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<StudentViewModel>> Add([FromBody] StudentViewModel studentViewModel)
        {
            // This maps the list of students to the DTO / View Model
            var studentDto = _mapper.Map<StudentViewModel>(await _studentService.AddStudent(_mapper.Map<Student>(studentViewModel)));
            return Created("api/[controller]", studentDto);
        }

    }
}
