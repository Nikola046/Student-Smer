using Microsoft.EntityFrameworkCore;
using Student_Smer.Models;

namespace Student_Smer.Data
{
    public class EFDBcontext:DbContext
    {
        public EFDBcontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Smer> Smers { get; set; }
    }
}
