using Student_Smer.Models;
using Student_Smer.Data;

namespace Student_Smer.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetWithFilter(string filter);
        Student? GetSingle(int id);
        int Save(Student student);
        void Delete(int id);
    }
}
