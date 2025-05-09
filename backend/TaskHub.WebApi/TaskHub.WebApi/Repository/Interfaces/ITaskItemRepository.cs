using TaskHub.WebApi.Models;

namespace TaskHub.WebApi.Repository.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAll();
        Task<TaskItem> GetById(int id);
        Task Create(TaskItem taskItem);
        Task Update(TaskItem taskItem);
        Task Delete(TaskItem taskItem);
    }
}
