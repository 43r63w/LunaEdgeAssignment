﻿using AutoMapper;
using LunaTask.BLL.Dtos;
using LunaTask.BLL.Dtos.Response;
using LunaTask.BLL.Dtos.Task;
using LunaTask.BLL.Dtos.User;
using LunaTask.BLL.IServices;
using LunaTask.DAL.Enums;
using LunaTask.DAL.IGenericRepository.Interfaces;
using System.Linq.Expressions;

namespace LunaTask.BLL.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> CreateTaskAsync(TaskCreateDto taskCreateDto)
        {
            var task = new LunaTask.DAL.Entities.Task
            {
                Id = Guid.NewGuid(),
                Title = taskCreateDto.Title,
                Description = taskCreateDto.Description,
                UserId = taskCreateDto.UserId,
                DueDate = taskCreateDto.DueDate ?? DateTime.UtcNow,
                Priority = taskCreateDto.Priority ?? Priority.Low,
                Status = taskCreateDto.Status ?? Status.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            _taskRepository.Add(task);
            await _taskRepository.SaveChangesAsync();

            return new ResponseDto(true, "Task created", task);
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync(GetTaskRequest getTaskRequest)
        {

            Expression<Func<DAL.Entities.Task, object>> selectorKey = getTaskRequest.SortItem switch
            {
                "date" => note => note.DueDate,
                "status" => note => note.Status,
                "priority" => note => note.Priority,
                _ => note => note.Id,
            };

            var tasks = await _taskRepository.SortAsync(selectorKey);

            var taskDto = tasks.Select(e => new TaskDto(
                 e.Title,
                 e.Description,
                 e.DueDate,
                 e.Status,
                 e.Priority,
                 e.UserId.ToString()
                )
            );

            return taskDto;
        }

        public async Task<TaskDto> GetTaskByIdAsync(string taskId)
        {
            var getTaskFromDb = await _taskRepository.GetAsync(e => e.Id.ToString() == taskId.ToString(),
                includeOptions: "User");

            if (getTaskFromDb == null)
                throw new InvalidOperationException("Task not found in the database.");

            var userDto = _mapper.Map<UserDto>(getTaskFromDb.User);

            var taskDto = new TaskDto(getTaskFromDb.Title,
                getTaskFromDb.Description,
                getTaskFromDb.DueDate,
                getTaskFromDb.Status,
                getTaskFromDb.Priority,
                getTaskFromDb.UserId.ToString() 
            );

            return taskDto;

        }

        public async Task<ResponseDto> UpdateTaskAsync(string taskId, TaskUpdateDto taskUpdateDto)
        {
            var taskFromDb = await _taskRepository.GetAsync(e => e.Id.ToString() == taskId);

            if (taskFromDb == null)
                throw new InvalidOperationException("Task not found in the database.");


            taskFromDb.Title = taskUpdateDto.Title;
            taskFromDb.Description = taskUpdateDto.Description;
            taskFromDb.Priority = taskUpdateDto.Priority;
            taskFromDb.Status = taskUpdateDto.Status;
            taskFromDb.DueDate = taskFromDb.DueDate;
            taskFromDb.UpdateAt = DateTime.UtcNow;


            _taskRepository.Update(taskFromDb);

            await _taskRepository.SaveChangesAsync();

            return new ResponseDto(true, "Task updated successfully");
        }

        public async Task<ResponseDto> DeleteTaskAsync(string taskId)
        {
            var task = await _taskRepository.GetAsync(e => e.Id.ToString() == taskId.ToString());

            if (task == null)
                throw new InvalidOperationException("Task not found in the database");

            _taskRepository.Delete(task);
            await _taskRepository.SaveChangesAsync();

            return new ResponseDto(true, "Task deleted");
        }




    }
}
