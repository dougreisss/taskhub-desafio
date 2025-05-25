using TaskHub.WebApi.Models;

namespace TaskHub.WebApi.Repository.Interfaces
{
    public interface ITaskStatusRepository
    {
        Task<List<Models.TaskStatus>> GetAll();
        Task<Models.TaskStatus> GetById(int id);
        Task Create(Models.TaskStatus taskStatus);
        Task Update(Models.TaskStatus taskStatus);
        Task Delete(Models.TaskStatus taskStatus);
    }
}
