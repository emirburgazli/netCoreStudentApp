using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Entity
{
	public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}

