using Microsoft.AspNetCore.Mvc;
using TestApi.ServiceLayer;
using TestApi.ServiceLayer.Abstraction;
using TestApi.Model;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDBController : ControllerBase
    {
        private IStudentService _service;

        public StudentDBController(IStudentService studentservice)
        {
            _service = studentservice;
        }
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            try
            {

                return Ok(_service.GetStudents());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetStudent/{StudentId}")]
        public async Task<ActionResult<Student>> Get(int StudentId)
        {
            try
            {
                return Ok(_service.GetStudent(StudentId));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult> Post(Student objstudent)
        {
            try
            {
                _service.AddStudent(objstudent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult> Put(Student objstudent)
        {

            try
            {
                var status = _service.UpdateStudent(objstudent);
                if (status)
                    return Ok();
                else
                    return Ok("Student Not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     

    }
}
