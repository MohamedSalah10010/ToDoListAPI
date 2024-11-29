using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Repo;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagmentController : ControllerBase
    {
        TaskRepo repo;
        public TaskManagmentController(TaskRepo repo)
        {
            this.repo = repo;
        }


        #region taskStatus
        [HttpPut("{id}/complete")]
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
