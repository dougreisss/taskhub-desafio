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
        private readonly ITaskItemServices _taskItemServices;

        public TaskController(ITaskItemServices taskItemServices)
        {
            _taskItemServices = taskItemServices;
        }

        // todo routes
    }
}
