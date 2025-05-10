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
        public DbSet<Models.TaskStatus> TaskStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.TaskStatus>().HasData(
                new Models.TaskStatus { Id = 1, Status = "Todo" },
                new Models.TaskStatus { Id = 2, Status = "Doing" },
                new Models.TaskStatus { Id = 3, Status = "Done" }
            ); 
        }
    }
}
