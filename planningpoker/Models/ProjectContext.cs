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
        
        public DbSet<UserProjectPermission> ProjectPermissions { get; set; }
        public DbSet<UserTaskEstimation> TaskEstimations { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}