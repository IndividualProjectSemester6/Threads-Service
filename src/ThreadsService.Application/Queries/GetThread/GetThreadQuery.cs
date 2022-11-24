using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Queries.GetThread
{
    public class GetThreadQuery : IRequest<ThreadDto>
    {
        public Guid Id { get; }

        public GetThreadQuery(Guid id)
        {
            Id = id;
        }
    }
}
