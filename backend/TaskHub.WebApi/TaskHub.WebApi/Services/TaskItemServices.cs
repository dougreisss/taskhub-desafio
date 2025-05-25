using AutoMapper;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Models;
using TaskHub.WebApi.Repository.Interfaces;
using TaskHub.WebApi.Services.Interfaces;

namespace TaskHub.WebApi.Services
{
    public class TaskItemServices : ITaskItemServices
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemServices(IMapper mapper, ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }

        public async Task<List<TaskItemDto>> GetAll()
        {
            var tasks = await _taskItemRepository.GetAll();

            return _mapper.Map<List<TaskItemDto>>(tasks);
        }

        public async Task<TaskItemDto> GetById(int id)
        {
            var task = await _taskItemRepository.GetById(id);

            return _mapper.Map<TaskItemDto>(task);
        }

        public async Task Create(CreateTaskItemDto createTaskItemDto)
        {
            var task = _mapper.Map<TaskItem>(createTaskItemDto);  
            await _taskItemRepository.Create(task);
        }

        public async Task Update(UpdateTaskItemDto updateTaskItemDto)
        {
            var task = await _taskItemRepository.GetById(updateTaskItemDto.Id);

            if (task == null)
            {
                throw new Exception("Task item not found");
            }

            _mapper.Map(updateTaskItemDto, task);

            await _taskItemRepository.Update(task);
        }

        public async Task Delete(int id)
        {
            var task = await _taskItemRepository.GetById(id);

            if (task == null)
            {
                throw new Exception("Task item not found");
            }

            await _taskItemRepository.Delete(task); 
        }

    }
}
