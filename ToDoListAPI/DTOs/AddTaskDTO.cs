using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs
{
    public class AddTaskDTO
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateOnly dueDate { get; set; }
        [Required]
        public Priority priority { get; set; }
    }
}
