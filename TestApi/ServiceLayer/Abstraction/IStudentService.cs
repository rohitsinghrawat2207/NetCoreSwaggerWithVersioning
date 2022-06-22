using TestApi.Model;
namespace TestApi.ServiceLayer.Abstraction
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student objstudent);
        bool UpdateStudent(Student objstudent);
       
    }
}
