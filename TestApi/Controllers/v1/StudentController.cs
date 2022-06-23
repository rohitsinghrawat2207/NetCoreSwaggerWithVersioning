using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Model;

namespace TestApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    public class StudentController : ControllerBase
    {
        public static List<StudentTest> stu = new List<StudentTest>();
        [HttpGet("GetAllStudents")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<StudentTest>>> Get()
        {
            return Ok(stu);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("GetStudent/{StudentId}")]
        public async Task<ActionResult<List<StudentTest>>> Get(int StudentId)
        {
            var stud = stu.Find(x => x.StudentId == StudentId);
            if (stud == null)
            {
                return BadRequest();
            }

            return Ok(stud);
        }

        [MapToApiVersion("1.0")]
        [HttpPost("AddStudent")]
        public async Task<ActionResult<List<StudentTest>>> Post(StudentTest objstudent)
        {
            stu.Add(objstudent);
            return Ok(stu);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<List<StudentTest>>> Put(StudentTest objstudent)
        {
            var stud = stu.Find(x => x.StudentId == objstudent.StudentId);
            if (stud == null)
            {
                return NotFound();
            }
            stud.Name = objstudent.Name;
            stud.Class = objstudent.Class;
            stud.Division = objstudent.Division;
            stud.Grade = objstudent.Grade;
            return Ok(stu);
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<List<StudentTest>>> Delete(StudentTest objstudent)
        {
            stu.Remove(objstudent);

            return Ok();
        }


    }
}
