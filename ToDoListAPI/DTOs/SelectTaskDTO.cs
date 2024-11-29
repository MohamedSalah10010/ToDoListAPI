using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs
{
    public class SelectTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public DateOnly dueDate { get; set; }
        public DateOnly creationDate { get; set; }

        public bool status { get; set; }

        public Priority priority { get; set; }
    }
}
