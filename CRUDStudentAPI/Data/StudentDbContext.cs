using CRUDStudentAPI.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentAPI.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Registration> Portal { get; set; }
    }
}
