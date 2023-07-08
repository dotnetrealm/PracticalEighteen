using Microsoft.EntityFrameworkCore;
using PracticalEighteen.Domain.Models;

namespace PracticalEighteen.Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedStudents();
        }

    }
}
