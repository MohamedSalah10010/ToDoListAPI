using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Repo;

namespace ToDoListAPI.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [EnableCors]
    public class ToDoListController : ControllerBase
    {

        TaskRepo repo;
        public ToDoListController(TaskRepo repo)
        {
            this.repo = repo;
        }

        #region TaskManagment
        [HttpGet]
        [SwaggerOperation(Summary = "Get all tasks", Description = "Fetches a list of all tasks. Status = false => incomplete and Status = true => complete. Priority levels are {0 => LOW, 1 => MED , 2 => HIGH}.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(List<SelectTaskDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found.")]
        [Produces("application/json")]

        public IActionResult getAllTasks()
        {
            var tasks = repo.selectAllTasks();
            if (!tasks.Any()) { return NotFound(); }
            else
            {
                List<SelectTaskDTO> selectTaskDTOs = new List<SelectTaskDTO>();
                foreach (var task in tasks)
                {

                    SelectTaskDTO selectTaskDTO = new SelectTaskDTO()
                    {
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        status = task.status,
                        creationDate = task.creationDate,
                        dueDate = task.dueDate,
                        priority = task.priority

                    };
                    selectTaskDTOs.Add(selectTaskDTO);

                }
                return Ok(selectTaskDTOs);

            }
        }
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a task by ID", Description = "Fetches a specific task by its ID. Status = false => incomplete and Status = true => complete. Priority levels are {0 => LOW, 1 => MED , 2 => HIGH}.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task retrieved successfully.", typeof(SelectTaskDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        [Produces("application/json")]

        public IActionResult getTaskById(int id)
        {
            var task = repo.selectTaskById(id);
            if (task == null) { return NotFound(); }
            else
            {

                SelectTaskDTO selectTaskDTO = new SelectTaskDTO()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    status = task.status,
                    creationDate = task.creationDate,
                    dueDate = task.dueDate,
                    priority = task.priority

                };

                return Ok(selectTaskDTO);

            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new task", Description = "Creates a new task with the provided details. Status = false => incomplete and Status = true => complete. Priority levels are {0 => LOW, 1 => MED , 2 => HIGH}. dueDate must be in this format { yyyy-mm-dd}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task created successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid task data.")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult createTask(AddTaskDTO taskDTO)
        {
            if (ModelState.IsValid)
            {
                TaskManagment task = new TaskManagment()
                {
                    Title = taskDTO.Title,
                    Description = taskDTO.Description,
                    status = false,
                    creationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                    dueDate = taskDTO.dueDate,
                    priority = taskDTO.priority

                };

                repo.addTask(task);
                repo.save();
                return Ok();
            }
            else { return BadRequest(ModelState); }

        }
        [HttpPut]
        [SwaggerOperation(Summary = "Edit an existing task", Description = "Updates an existing task with new details.Status = false => incomplete and Status = true => complete. Priority levels are {0 => LOW, 1 => MED , 2 => HIGH}. dueDate must be in this format { yyyy-mm-dd}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task updated successfully.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid task data.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult editTask(EditTaskDTO taskDTO)
        {
            if (ModelState.IsValid)
            {
                var task = repo.selectTaskById(taskDTO.Id);
                if (task == null) { return NotFound(); }
                else
                {
                    task.Title = taskDTO.Title;
                    task.Description = taskDTO.Description;
                    task.status = taskDTO.status;
                    task.dueDate = taskDTO.dueDate;
                    task.priority = taskDTO.priority;
                    task.creationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                    repo.updateTask(task);
                    repo.save();
                    return Ok();
                }


            }
            else { return BadRequest(); }

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a task", Description = "Deletes a task by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task deleted successfully.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        [Produces("application/json")]

        public IActionResult deleteTask(int id) {

            var task = repo.selectTaskById(id);
            if (task == null) { return NotFound(); }
            else
            {
                repo.removeTask(task);
                repo.save();
                return Ok();
            }
        }

        #endregion

       

    }
}
