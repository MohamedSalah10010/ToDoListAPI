using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Repo;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TaskManagmentController : ControllerBase
    {
        TaskRepo repo;
        public TaskManagmentController(TaskRepo repo)
        {
            this.repo = repo;
        }


        #region taskStatus
        [HttpPut("{id}/complete")]
        [SwaggerOperation(Summary = "Mark a task as complete", Description = "Updates the task status to complete.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task marked as complete.", typeof(SelectTaskDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        [Produces("application/json")]
        public IActionResult MarkTaskComplete(int id)
        {
            var task = repo.selectTaskById(id);
            if (task == null) { return NotFound(); }
            else
            {
                task.status = true;
                repo.updateTask(task);
                repo.save();
                SelectTaskDTO taskDTO = new SelectTaskDTO()
                {
                    Id = id,
                    dueDate = task.dueDate,
                    priority = task.priority,
                    Title = task.Title,
                    Description = task.Description,
                    status = task.status,
                    creationDate = task.creationDate

                };
                return Ok(taskDTO);
            }
        }

        [HttpPut("{id}/incomplete")]
        [SwaggerOperation(Summary = "Mark a task as incomplete", Description = "Updates the task status to incomplete.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task marked as incomplete.", typeof(SelectTaskDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        [Produces("application/json")]
        public IActionResult MarkTaskIncomplete(int id)
        {
            var task = repo.selectTaskById(id);
            if (task == null) { return NotFound(); }
            else
            {
                task.status = false;
                repo.updateTask(task);
                repo.save();
                SelectTaskDTO taskDTO = new SelectTaskDTO()
                {
                    Id = id,
                    dueDate = task.dueDate,
                    priority = task.priority,
                    Title = task.Title,
                    Description = task.Description,
                    status = task.status,
                    creationDate = task.creationDate

                };
                return Ok(taskDTO);
            }
        }

        #endregion

        #region FilteringTasks

        [HttpGet("status")]
        [SwaggerOperation(Summary = "Get tasks by status", Description = "Fetches tasks based on their completion status.\n Status = false => incomplete and Status = true => complete")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(List<SelectTaskDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found with the specified status.")]
        [Produces("application/json")]
        public IActionResult getTasksByStatus([FromQuery] bool status)
        {
            var tasks = repo.selectAllTasks().Where(t => t.status == status);
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
        [HttpGet("date")]
        [SwaggerOperation(Summary = "Get tasks by due date", Description = "Fetches tasks based on their due date.\n Must be{yyyy-mm-dd} ")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(List<SelectTaskDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found with the specified due date.")]
        [Produces("application/json")]
        public IActionResult getTasksByDueDate([FromQuery] DateOnly dueDate)
        {
            var tasks = repo.selectAllTasks().Where(t => t.dueDate == dueDate);
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

        #endregion

        #region Task Priorities
        [HttpGet("priority")]
        [SwaggerOperation(Summary = "Get tasks by priority", Description = "Fetches tasks based on their priority level. Priority levels are {0 => LOW, 1 => MED , 2 => HIGH}. ")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(List<SelectTaskDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found with the specified priority.")]
        [Produces("application/json")]
        public IActionResult getTasksByPriority([FromQuery] Priority priority)
        {
            var tasks = repo.selectAllTasks().Where(t => t.priority == priority);
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



        [HttpPut("{id}/priority")]
        [SwaggerOperation(Summary = "Set task priority", Description = "Updates the priority level of a task. Priority levels are {0 => LOW, 1 => MED , 2 => HIGH}.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task priority updated successfully.", typeof(SelectTaskDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult SetTaskPriority(int id, [FromQuery] Priority priority)
        {
            var task = repo.selectTaskById(id);
            if (task == null) { return NotFound(); }
            else
            {

                task.priority = priority;
                repo.updateTask(task);
                repo.save();
                SelectTaskDTO taskDTO = new SelectTaskDTO()
                {
                    Id = id,
                    dueDate = task.dueDate,
                    priority = task.priority,
                    Title = task.Title,
                    Description = task.Description,
                    status = task.status,
                    creationDate = task.creationDate

                };
                return Ok(taskDTO);
            }
        }

        #endregion
    }
}
