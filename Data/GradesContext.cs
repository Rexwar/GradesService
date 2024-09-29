using Microsoft.EntityFrameworkCore;
using GradesService.Models;

namespace GradesService.Data
{
    public class GradesContext : DbContext
    {
        public GradesContext(DbContextOptions<GradesContext> options) : base(options)
        {
        }

        public DbSet<Grade> Grades { get; set; }
    }
}
