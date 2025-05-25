using System.Threading.Tasks;
using TaskHub.WebApi.DTOs;

namespace TaskHub.WebApi.Services.Interfaces
{
    public interface ITaskItemServices
    {
        Task<List<TaskItemDto>> GetAll();
        Task<TaskItemDto> GetById(int id);
        Task Create(CreateTaskItemDto createTaskItemDto);
        Task Update(UpdateTaskItemDto updateTaskItemDto);
        Task Delete(int id);
    }
}
