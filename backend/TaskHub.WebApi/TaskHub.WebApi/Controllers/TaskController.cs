using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHub.WebApi.Services.Interfaces;

namespace TaskHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemServices _taskItemServices;

        public TaskController(IMapper mapper, ITaskItemServices taskItemServices)
        {
            _mapper = mapper;
            _taskItemServices = taskItemServices;
        }

        // todo routes
    }
}
