using MediatR;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Queries.GetAllThreads
{
    public class GetAllThreadsHandler : IRequestHandler<GetAllThreadsQuery, IEnumerable<ThreadDto>>
    {
        private readonly IQueryThreadRepository _repository;

        public GetAllThreadsHandler(IQueryThreadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ThreadDto>> Handle(GetAllThreadsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
