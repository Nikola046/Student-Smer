using Student_Smer.Data;
using Student_Smer.Models;

namespace Student_Smer.Repository.SQL
{
    public class SmerSQLRepository : ISmerRepository
    {
        private readonly EFDBcontext _dbcontext;
        public SmerSQLRepository(EFDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Smer> GetAll()
        {
            return _dbcontext.Smers.ToList();
        }

        public List<Smer> GetWithFilter(string filter)
        {
            filter = filter.ToLower();
            return _dbcontext.Smers.Where(s => s.NazivSmera.Contains(filter) || s.Sifra.Contains(filter)).ToList();
        }

        public Smer? GetSingle(int id)
        {
            return _dbcontext.Smers.FirstOrDefault(s => s.SmerID == id);
        }

        public int Save(Smer smer)
        {
            if (smer.SmerID == 0)
            {
                _dbcontext.Smers.Add(smer);
            }
            else
            {
                _dbcontext.Smers.Update(smer);
            }
            _dbcontext.SaveChanges();

            return smer.SmerID;
        }

        public void Delete(int id)
        {
            var smer = new Smer() { SmerID = id };
            _dbcontext.Smers.Attach(smer);
            _dbcontext.Smers.Remove(smer);
            _dbcontext.SaveChanges();
        }
    }
}
