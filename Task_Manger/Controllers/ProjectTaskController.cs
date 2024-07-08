using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Manger.DTO;
using Task_Manger.Models;
using Task_Manger.Service;

namespace Task_Manger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public ProjectTaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasksList = _taskService.GetAll().Select(t => t.ToTaskResponseDTO());
            return Ok(tasksList);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.Get(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task.ToTaskResponseDTO());
        }
        [HttpPost]
        public IActionResult Add(TaskRequestDTO taskRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = _taskService.Add(taskRequestDTO.ToProjectTask());

            return CreatedAtAction(nameof(GetById), new {id=task.TaskId});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var task = _taskService.Get(id);
            if (task == null)
                return NotFound();

            _taskService.Delete(task);
            return NoContent();

        }

        [HttpPut]
        public IActionResult Edit(TaskUpdateDTO TaskUpdateDTO)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = _taskService.Update(TaskUpdateDTO.ToProjectTask());
            return NoContent();

        }
    }
}
