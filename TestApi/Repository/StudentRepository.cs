using TestApi.Model;
using TestApi.Repository.Abstraction;

namespace TestApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDBContext _dbcontext;

        public StudentRepository(StudentDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddStudent(Student objstudent)
        {
            try
            {
                _dbcontext.Students.Add(objstudent);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool checkexist(int StudentId)
        {
            var student = _dbcontext.Students.Find(StudentId);
            if (student == null)
            {
                return false;
            }
            return true;
        }

      

        public Student GetStudent(int id)
        {
            try
            {
                var student = _dbcontext.Students.Where(x => x.StudentId == id).FirstOrDefault();
                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Student> GetStudents()
        {
            try
            { return _dbcontext.Students.ToList(); }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateStudent(Student objstudent)
        {
            try
            {
                var student = _dbcontext.Students.Find(objstudent.StudentId);

                student.Name = objstudent.Name;
                student.Class = objstudent.Class;
                student.Division = objstudent.Division;
                student.Grade = objstudent.Grade;
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
