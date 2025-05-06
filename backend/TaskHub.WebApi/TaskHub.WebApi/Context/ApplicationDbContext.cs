using Microsoft.EntityFrameworkCore;
using TaskHub.WebApi.Models;

namespace TaskHub.WebApi.Context
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        {
            
        }

        public DbSet<TaskItem> TaskItem { get; set; }
    }
}
