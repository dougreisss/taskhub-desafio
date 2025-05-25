using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskHub.WebApi.DTOs;

namespace TaskHub.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected ObjectResult ReturnInternalServerError<T>(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto<T>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Internal Server Error",
                Exception = ex.Message
            });
        }

        protected ObjectResult ReturnNotFound<T>(string message = "Item not found")
        {
            return NotFound(new ApiResponseDto<T>
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = message
            });
        }

        protected ObjectResult ReturnOk<T>(T? data, string message = "Success")
        {
            return Ok(new ApiResponseDto<T>
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Success",
                Data = data
            });
        }
    }
}
