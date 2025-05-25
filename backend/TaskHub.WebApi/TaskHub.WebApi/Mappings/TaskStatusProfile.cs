using AutoMapper;
using TaskHub.WebApi.DTOs;

namespace TaskHub.WebApi.Mappings
{
    public class TaskStatusProfile : Profile
    {
        public TaskStatusProfile()
        {
            CreateMap<Models.TaskStatus, TaskStatusDto>().ReverseMap();
        }
    }
}
