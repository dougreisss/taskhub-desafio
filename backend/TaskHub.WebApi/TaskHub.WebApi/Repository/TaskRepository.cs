using Microsoft.EntityFrameworkCore;
using TaskHub.WebApi.Context;
using TaskHub.WebApi.Models;
using TaskHub.WebApi.Repository.Interfaces;

namespace TaskHub.WebApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAll()
        {
            return await _context.TaskItem.ToListAsync();
        }

        public async Task<TaskItem> GetById(int id)
        {
            return await _context.TaskItem.FindAsync(id);
        }

        public async Task Create(TaskItem taskItem)
        {
            await _context.TaskItem.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TaskItem taskItem)
        {
            _context.TaskItem.Update(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TaskItem taskItem)
        {
            _context.TaskItem.Remove(taskItem);
            await _context.SaveChangesAsync();  
        }
    }
}
