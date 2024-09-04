using LunaTask.BLL.Dtos;
using LunaTask.BLL.Dtos.Response;
using LunaTask.BLL.Dtos.Task;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace LunaTask.BLL.IServices
{
    public interface ITaskService
    {

        Task<IEnumerable<TaskDto>> GetTasksAsync(GetTaskRequest getTaskRequest);
        Task<TaskDto> GetTaskByIdAsync(string taskId);
        Task<ResponseDto> CreateTaskAsync(TaskCreateDto taskCreateDto);
        Task<ResponseDto> UpdateTaskAsync(string taskId,TaskUpdateDto taskUpdateDto);

        Task<ResponseDto> DeleteTaskAsync(string taskId);


    }
}
