using TestApi.Model;
using TestApi.ServiceLayer.Abstraction;
using TestApi.Repository.Abstraction;
namespace TestApi.ServiceLayer
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public void AddStudent(Student objstudent)
        {
            try
            {
                _repo.AddStudent(objstudent);
            }
            catch (Exception)
            {
                throw;
            }
        }

      

        public Student GetStudent(int id)
        {
            try
            {
                return _repo.GetStudent(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                return _repo.GetStudents();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateStudent(Student objstudent)
        {
            try
            {


                if (checkexist(objstudent.StudentId))
                {
                    _repo.UpdateStudent(objstudent);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool checkexist(int StudentId)
        {
            return _repo.checkexist(StudentId);
        }
    }
}
