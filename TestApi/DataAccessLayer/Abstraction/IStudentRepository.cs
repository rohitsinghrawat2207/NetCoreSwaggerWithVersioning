using TestApi.Model;

namespace TestApi.DataAccessLayer.Abstraction
{
    public interface IStudentDataAccessLayer
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student objstudent);
        void UpdateStudent(Student objstudent);
  
        bool checkexist(int StudentId);
    }
}
