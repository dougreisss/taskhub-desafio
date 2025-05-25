using Microsoft.EntityFrameworkCore;
using TaskHub.WebApi.Context;
using TaskHub.WebApi.Repository.Interfaces;

namespace TaskHub.WebApi.Repository
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Models.TaskStatus>> GetAll()
        {
            return await _context.TaskStatus.ToListAsync();
        }
        public async Task<Models.TaskStatus> GetById(int id)
        {
            return await _context.TaskStatus.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Models.TaskStatus taskStatus)
        {
            _context.TaskStatus.Add(taskStatus);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Models.TaskStatus taskStatus)
        {
           _context.Update(taskStatus);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Models.TaskStatus taskStatus)
        {
           _context.Remove(taskStatus);
           await _context.SaveChangesAsync();  
        }
    }
}
