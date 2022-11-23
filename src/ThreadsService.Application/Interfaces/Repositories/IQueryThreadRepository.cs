using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Interfaces.Repositories
{
    public interface IQueryThreadRepository
    {
        Task<IEnumerable<ThreadDto>> GetAll();
        Task<ThreadDto?> Get(Guid id);
    }
}