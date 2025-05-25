using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Models;
using TaskHub.WebApi.Services.Interfaces;

namespace TaskHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController
    {
        private readonly ITaskItemServices _taskItemServices;

        public TaskController(ITaskItemServices taskItemServices)
        {
            _taskItemServices = taskItemServices;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseDto<List<TaskItemDto>>>> GetAll()
        {
            try
            {
                List<TaskItemDto> tasks = await _taskItemServices.GetAll();

                if (tasks == null) 
                {
                    return ReturnNotFound<List<TaskItemDto>>("Tasks Items Not Found");
                }

                return ReturnOk(tasks);
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskItemDto>(ex);
            }
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> GetById(int id)
        {
            try
            {
                TaskItemDto task = await _taskItemServices.GetById(id);

                if (task == null)
                {
                    return ReturnNotFound<TaskItemDto>("Task Item Not Found");
                }

                return ReturnOk(task);
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskItemDto>(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> Create(CreateTaskItemDto taskItemDto)
        {
            try
            {
                // TODO
                // validar se status existe 

                await _taskItemServices.Create(taskItemDto);

                return ReturnOk(taskItemDto, "Task item created successfully");
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<CreateTaskItemDto>(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> Update(UpdateTaskItemDto updateTaskItemDto)
        {
            try
            {
                // TODO 
                // validar se status existe 

                await _taskItemServices.Update(updateTaskItemDto);

                return ReturnOk(updateTaskItemDto, "Task item updated successfully");
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<UpdateTaskItemDto>(ex);
            }
        }

        [HttpDelete("{id}")]    
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> Delete(int id)
        {
            try
            {
                await _taskItemServices.Delete(id);

                return ReturnOk<TaskItemDto>(null, message: "Task item deleted successfully");

            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskItemDto>(ex);
            }
        }
    }
}
