using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHub.WebApi.Models
{
    [Table("TaskItem")]
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]    
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
