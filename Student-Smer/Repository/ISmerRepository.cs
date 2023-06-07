using Student_Smer.Models;
using Student_Smer.Data;

namespace Student_Smer.Repository
{
    public interface ISmerRepository
    {
        List<Smer> GetAll();
        List<Smer> GetWithFilter(string filter);
        Smer GetSingle(int id);
        int Save(Smer smer);
        void Delete(int id);
    }
}
