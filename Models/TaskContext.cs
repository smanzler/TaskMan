using Microsoft.EntityFrameworkCore;

namespace TaskMan.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Name = "Move Load", Description = "Move load from EEDIV to EEDI", Created = DateTime.Now, Completed = false}
            );
        }
    }
}
