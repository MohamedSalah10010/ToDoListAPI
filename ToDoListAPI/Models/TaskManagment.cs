namespace ToDoListAPI.Models
{
   
    public class TaskManagment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public DateOnly dueDate { get; set; }
        public DateOnly creationDate { get; set; }

        public bool status { get; set; } = false; // false = incomplete , true = complete
    
        public Priority priority { get; set; } = Priority.LOW; 
    }
    public enum Priority
    {
        LOW,
        MEDIUM,
        HIGH
    }
}
