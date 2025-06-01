using System.ComponentModel.DataAnnotations;

namespace TaskHub.WebApi.Models
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        public required string Status { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
