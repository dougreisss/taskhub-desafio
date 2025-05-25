using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHub.WebApi.DTOs;
using TaskHub.WebApi.Services.Interfaces;

namespace TaskHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : BaseController
    {
        private readonly ITaskStatusServices _taskStatusServices;
        public TaskStatusController(ITaskStatusServices taskStatusServices)
        {
            _taskStatusServices = taskStatusServices;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseDto<List<TaskStatusDto>>>> GetAll()
        {
            try
            {
                List<TaskStatusDto> taskStatus = await _taskStatusServices.GetAll();

                if (taskStatus == null) 
                {
                    return ReturnNotFound<List<TaskStatusDto>>("Task Status not found");
                }

                return ReturnOk(taskStatus);
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskStatusDto>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponseDto<TaskStatusDto>>> GetById(int id)
        {
            try
            {
                TaskStatusDto taskStatus = await _taskStatusServices.GetById(id);

                if (taskStatus == null)
                {
                    return ReturnNotFound<TaskStatusDto>("Task Status not found");
                }

                return ReturnOk(taskStatus);
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskStatusDto>(ex);
            }
        }

        [HttpPost]  
        public async Task<ActionResult<ApiResponseDto<TaskStatusDto>>> Create(TaskStatusDto taskStatusDto)
        {
            try
            {
                await _taskStatusServices.Create(taskStatusDto);

                return ReturnOk(taskStatusDto, "Task status created successfully"); 
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskStatusDto>(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponseDto<TaskStatusDto>>> Update(TaskStatusDto taskStatusDto)
        {
            try
            {
                await _taskStatusServices.Update(taskStatusDto);

                return ReturnOk(taskStatusDto, "Task status updated successfully");
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskStatusDto>(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponseDto<TaskStatusDto>>> Delete(int id)
        {
            try
            {
                await _taskStatusServices.Delete(id);

                return ReturnOk<TaskStatusDto>(null, message: "Task status deleted sucessfully");
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError<TaskStatusDto>(ex);
            }
        }
    }
}
