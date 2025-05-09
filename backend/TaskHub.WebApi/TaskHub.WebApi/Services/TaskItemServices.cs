using TaskHub.WebApi.Repository.Interfaces;
using TaskHub.WebApi.Services.Interfaces;

namespace TaskHub.WebApi.Services
{
    public class TaskItemServices : ITaskItemServices
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemServices(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
    }
}
