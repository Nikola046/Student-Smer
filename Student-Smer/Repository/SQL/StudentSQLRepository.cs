using Student_Smer.Data;
using Student_Smer.Models;

namespace Student_Smer.Repository.SQL
{
    public class StudentSQLRepository : IStudentRepository
    {
        private readonly EFDBcontext _dbcontext;
        public StudentSQLRepository(EFDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbcontext.Students.ToList();
        }

        public IEnumerable<Student> GetWithFilter(string filter)
        {
            filter = filter.ToLower();
            return _dbcontext.Students.Where(s => s.Ime.Contains(filter) || s.Smer.NazivSmera.Contains(filter));
        }

        public Student? GetSingle(int id)
        {
            return _dbcontext.Students.FirstOrDefault(s => s.StudentID == id);
        }

        public void Delete(int id)
        {
            var student = _dbcontext.Students.FirstOrDefault(s => s.StudentID == id);
            _dbcontext.Students.Remove(student);
            _dbcontext.SaveChanges();
        }

        public int Save(Student student)
        {
            if (student.StudentID == 0)
            {
                _dbcontext.Students.Add(student);
            }
            else
            {
                _dbcontext.Students.Update(student);
            }
            _dbcontext.SaveChanges();

            return student.StudentID;
        }
    }
}
