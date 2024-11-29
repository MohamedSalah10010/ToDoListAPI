using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Models
{
    public class TaskDBContext:DbContext
    {
        public virtual DbSet<TaskManagment> Tasks { get; set; }
      
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

                        base.OnModelCreating(modelBuilder);
                        modelBuilder.Entity<TaskManagment>().HasData(
                new TaskManagment
                {
                    Id = 1,
                    Title = "Complete Documentation",
                    Description = "Write and complete the project documentation.",
                    dueDate = new DateOnly(2024, 12, 15),
                    creationDate = new DateOnly(2024, 11, 29),
                    status = false,
                    priority = Priority.HIGH
                },
                new TaskManagment
                {
                    Id = 2,
                    Title = "Code Review",
                    Description = "Review the code before submission.",
                    dueDate = new DateOnly(2024, 12, 10),
                    creationDate = new DateOnly(2024, 11, 25),
                    status = false,
                    priority = Priority.MEDIUM
                },
                new TaskManagment
                {
                    Id = 3,
                    Title = "Testing",
                    Description = "Test the functionality of the project.",
                    dueDate = new DateOnly(2024, 12, 5),
                    creationDate = new DateOnly(2024, 11, 28),
                    status = true,
                    priority = Priority.LOW
                },
                new TaskManagment
                {
                    Id = 4,
                    Title = "Client Meeting",
                    Description = "Discuss the project requirements with the client.",
                    dueDate = new DateOnly(2024, 12, 1),
                    creationDate = new DateOnly(2024, 11, 30),
                    status = true,
                    priority = Priority.HIGH
                }
            );
        }

    }
}

