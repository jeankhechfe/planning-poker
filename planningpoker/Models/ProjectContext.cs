using Microsoft.EntityFrameworkCore;

namespace planningpoker.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Project> ProjectItems { get; set; }
    }
}