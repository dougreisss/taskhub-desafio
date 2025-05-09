using TaskHub.WebApi.DTOs;

namespace TaskHub.WebApi.Services.Interfaces
{
    public interface ITaskItemServices
    {
        Task<List<TaskItemDto>> GetAll();
        Task<TaskItemDto> GetById(int id);
        Task Create(TaskItemDto taskItemDto);
        Task Update(TaskItemDto taskItemDto);
        Task Delete(TaskItemDto taskItemDto);
    }
}
