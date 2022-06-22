using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Model;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<StudentTest> stu = new List<StudentTest>();
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<StudentTest>>> Get()
        {
            return Ok(stu);
        }

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

        [HttpPost("AddStudent")]
        public async Task<ActionResult<List<StudentTest>>> Post(StudentTest objstudent)
        {
            stu.Add(objstudent);
            return Ok(stu);
        }

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

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<List<StudentTest>>> Delete(StudentTest objstudent)
        {
            stu.Remove(objstudent);

            return Ok();
        }


    }
}
