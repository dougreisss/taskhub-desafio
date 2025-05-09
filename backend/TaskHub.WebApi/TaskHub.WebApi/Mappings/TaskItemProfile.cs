using AutoMapper;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Models;

namespace TaskHub.WebApi.Mappings
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDTO>().ReverseMap();
        }
    }
}
