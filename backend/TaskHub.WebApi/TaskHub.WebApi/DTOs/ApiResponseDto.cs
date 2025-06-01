namespace TaskHub.WebApi.DTOs
{
    public class ApiResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public T? Data { get; set; }
    }
}
