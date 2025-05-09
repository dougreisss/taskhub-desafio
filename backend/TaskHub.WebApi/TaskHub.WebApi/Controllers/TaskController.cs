using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHub.WebApi.DTOs;
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

        [HttpGet]
        public async Task<ActionResult<ApiResponseDto<List<TaskItemDto>>>> GetAll()
        {
            try
            {
                List<TaskItemDto> tasks = await _taskItemServices.GetAll();

                if (tasks == null) 
                {
                    return NotFound(new ApiResponseDto<List<TaskItemDto>>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "Tasks Item Not Found"
                    });
                }

                return Ok(new ApiResponseDto<List<TaskItemDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = tasks
                });
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError(ex);
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
                    return NotFound(new ApiResponseDto<TaskItemDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "Task item Not Found"
                    });
                }

                return Ok(new ApiResponseDto<TaskItemDto>
                {
                    StatusCode = StatusCodes.Status200OK,   
                    Message = "Success",
                    Data = task
                });
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> Create(TaskItemDto taskItemDto)
        {
            try
            {
                await _taskItemServices.Create(taskItemDto);

                return Ok(new ApiResponseDto<TaskItemDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Task item created successfully",
                    Data = taskItemDto
                });
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> Update(TaskItemDto taskItemDto)
        {
            try
            {
                await _taskItemServices.Update(taskItemDto);

                return Ok(new ApiResponseDto<TaskItemDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Task item updated successfully",
                    Data = taskItemDto
                });
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError(ex);
            }
        }

        [HttpDelete]    
        public async Task<ActionResult<ApiResponseDto<TaskItemDto>>> Delete(TaskItemDto taskItemDto)
        {
            try
            {
                await _taskItemServices.Delete(taskItemDto);

                return Ok(new ApiResponseDto<TaskItemDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Task item deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return ReturnInternalServerError(ex);
            }
        }

        private ObjectResult ReturnInternalServerError(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto<TaskItemDto>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Internal Server Error",
                Exception = ex.Message
            });
        }
    }
}
