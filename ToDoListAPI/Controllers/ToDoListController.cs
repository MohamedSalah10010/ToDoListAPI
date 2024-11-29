using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Repo;

namespace ToDoListAPI.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {

        TaskRepo repo;
        public ToDoListController(TaskRepo repo)
        {
            this.repo = repo;
        }

        #region TaskManagment
        [HttpGet]
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
