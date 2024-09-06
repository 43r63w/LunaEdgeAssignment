using LunaTask.BLL.Dtos.Request;
using LunaTask.BLL.Dtos.Task;
using LunaTask.BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace LunaTask.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }



        [HttpGet("/tasks")]
        public async Task<ActionResult<List<TaskDto>>> GetAll([FromQuery]GetTaskRequest getTaskRequest)
        {
            var tasks = await _taskService.GetTasksAsync(getTaskRequest);        
            return Ok(tasks);
        }


        [HttpGet("/task/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return Ok(task);
        }

        [HttpPost("/task")]
        public async Task<ActionResult> Post(TaskCreateDto taskCreateDto)
        {
            var result = await _taskService.CreateTaskAsync(taskCreateDto);
            return Ok(result);
        }

        [HttpPut("/task/{id}")]
        public async Task<ActionResult> Put(string id, TaskUpdateDto taskUpdateDto)
        {
            var result = await _taskService.UpdateTaskAsync(id, taskUpdateDto);
            return Ok(result);
        }

        [HttpDelete("/task/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            return Ok(result);
        }
    }
}
