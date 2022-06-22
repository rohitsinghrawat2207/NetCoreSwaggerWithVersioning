using TestApi.Model;

namespace TestApi.Repository.Abstraction
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student objstudent);
        void UpdateStudent(Student objstudent);
  
        bool checkexist(int StudentId);
    }
}
