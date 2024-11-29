using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs
{
    public class EditTaskDTO
    {
        [Required]
        public int Id { get; set; }
 
        public string Title { get; set; }
        public string? Description { get; set; }

        public DateOnly dueDate { get; set; }
        
        public bool status { get; set; }

        public Priority priority { get; set; }
    }
}
