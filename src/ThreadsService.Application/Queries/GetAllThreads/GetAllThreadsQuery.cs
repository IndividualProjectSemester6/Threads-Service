using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Queries.GetAllThreads
{
    public class GetAllThreadsQuery : IRequest<IEnumerable<ThreadDto>>
    {
    }
}
