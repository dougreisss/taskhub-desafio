using System.Threading.Tasks;
using AutoMapper;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Repository.Interfaces;
using TaskHub.WebApi.Services.Interfaces;

namespace TaskHub.WebApi.Services
{
    public class TaskStatusServices : ITaskStatusServices
    {
        private readonly IMapper _mapper;
        private readonly ITaskStatusRepository _taskStatusRepository;
        public TaskStatusServices(IMapper mapper, ITaskStatusRepository taskStatusRepository)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
        }
        public async Task<List<TaskStatusDto>> GetAll()
        {
            var taskStatus = await _taskStatusRepository.GetAll();

            return _mapper.Map<List<TaskStatusDto>>(taskStatus);
        }

        public async Task<TaskStatusDto> GetById(int id)
        {
            var taskStatus = await _taskStatusRepository.GetById(id);

            return _mapper.Map<TaskStatusDto>(taskStatus);
        }

        public async Task Create(TaskStatusDto taskStatusDto)
        {
            var taskStatus = _mapper.Map<Models.TaskStatus>(taskStatusDto);
            await _taskStatusRepository.Create(taskStatus);
        }
        public async Task Update(TaskStatusDto taskStatusDto)
        {
            var taskStatus = await _taskStatusRepository.GetById(taskStatusDto.Id);

            if (taskStatus == null)
            {
                throw new Exception("Task status not found");
            }

            _mapper.Map(taskStatusDto, taskStatus);

            await _taskStatusRepository.Update(taskStatus);
        }
        public async Task Delete(int id)
        {
            var taskStatus = await _taskStatusRepository.GetById(id);

            if (taskStatus == null)
            {
                throw new Exception("Task status not found");
            }

            await _taskStatusRepository.Delete(taskStatus); 
        }
    }
}
