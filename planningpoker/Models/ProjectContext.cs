using Microsoft.EntityFrameworkCore;

namespace planningpoker.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Project> Projects { get; set; }
        
        public DbSet<ProjectPermission> ProjectPermissions { get; set; }
        
        public DbSet<User> Users { get; set; }
    }
}