using AutoMapper;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Models;

namespace TaskHub.WebApi.Mappings
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new TaskStatusDto
                {
                    Id = src.Status.Id,
                    Status = src.Status.Status
                })).ReverseMap();

            CreateMap<CreateTaskItemDto, TaskItem>()
             .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));

            CreateMap<UpdateTaskItemDto, TaskItem>()
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            .ForMember(dest => dest.Status, opt => opt.Ignore()); 
        }
    }
}
