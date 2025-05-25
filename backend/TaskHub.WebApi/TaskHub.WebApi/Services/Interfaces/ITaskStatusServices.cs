using TaskHub.WebApi.DTOs;

namespace TaskHub.WebApi.Services.Interfaces
{
    public interface ITaskStatusServices
    {
        Task<List<TaskStatusDto>> GetAll();
        Task<TaskStatusDto> GetById(int id);
        Task Create (TaskStatusDto taskStatusDto);
        Task Update (TaskStatusDto taskStatusDto);
        Task Delete (int id);
    }
}
