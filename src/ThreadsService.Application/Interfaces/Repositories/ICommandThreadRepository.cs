using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Interfaces.Repositories
{
    public interface ICommandThreadRepository
    {
        Task<ThreadDto> CreateThread(ThreadDto thread);
        Task<ThreadDto?> DeleteThread(Guid id);
        Task<ThreadDto?> UpdateThread(ThreadDto thread);
    }
}
