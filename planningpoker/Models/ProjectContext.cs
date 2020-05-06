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
        
        public DbSet<User> Users { get; set; }

        public DbSet<Epic> Epics { get; set; }

        public DbSet<Task> Tasks { get; set; }

        //protected virtual void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship between Project & Epic
        //    modelBuilder.Entity<Epic>()
        //        .HasRequired<Project>(e => e.Project)
        //        .WithMany(p => p.Epics)
        //        .HasForeignKey<int>(e => e.ProjectId);

        //    // configures one-to-many relationship between Epic & Task
        //    modelBuilder.Entity<Task>()
        //        .HasRequired<Epic>(t => t.Epic)
        //        .WithMany(e => e.Tasks)
        //        .HasForeignKey<int>(t => t.EpicId);

        //    // configures many-to-many relationship between User & Task
        //    modelBuilder.Entity<Task>()
        //        .HasMany<User>(t => t.Users)
        //        .WithMany(u => u.Tasks)
        //        .Map(ut =>
        //        {
        //            ut.MapLeftKey("UserRefId");
        //            ut.MapRightKey("TaskRefId");
        //            ut.ToTable("UserTask");
        //        });
        //}
    }
}