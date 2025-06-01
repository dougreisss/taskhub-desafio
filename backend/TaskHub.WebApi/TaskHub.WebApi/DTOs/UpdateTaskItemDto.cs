namespace TaskHub.WebApi.DTOs
{
    public class UpdateTaskItemDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
