using Microsoft.EntityFrameworkCore;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;
using ThreadsService.Infrastructure.Contexts;

namespace ThreadsService.Infrastructure.Repositories
{
    public class CommandThreadRepository : ICommandThreadRepository
    {
        private readonly ThreadDbContext _dbContext;

        public CommandThreadRepository(ThreadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ThreadDto> CreateThread(ThreadDto thread)
        {
            await _dbContext.AddAsync(thread);
            await _dbContext.SaveChangesAsync();
            return thread;
        }

        public Task<ThreadDto?> DeleteThread(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ThreadDto?> UpdateThread(ThreadDto thread)
        {
            var existing = await _dbContext.Threads.FindAsync(thread.Id);
            if (existing == null) return null;
            existing.TopicName = thread.TopicName;
            existing.Content = thread.Content;
            existing.LastEdited = thread.LastEdited;
            await _dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
