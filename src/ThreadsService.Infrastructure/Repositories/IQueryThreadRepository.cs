using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;
using ThreadsService.Infrastructure.Contexts;

namespace ThreadsService.Infrastructure.Repositories
{
    public class QueryThreadRepository : IQueryThreadRepository
    {
        private readonly ThreadDbContext _dbContext;

        public QueryThreadRepository(ThreadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ThreadDto>> GetAll()
        {
            return await _dbContext.Threads.ToListAsync();
        }

        public async Task<ThreadDto?> Get(Guid id)
        {
            return await _dbContext.Threads.FindAsync(id);
        }
    }
}
