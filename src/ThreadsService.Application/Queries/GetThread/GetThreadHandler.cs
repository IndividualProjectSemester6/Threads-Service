using MediatR;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Queries.GetThread
{
    public class GetThreadHandler : IRequestHandler<GetThreadQuery, ThreadDto?>
    {
        private readonly IQueryThreadRepository _repository;

        public GetThreadHandler(IQueryThreadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ThreadDto?> Handle(GetThreadQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }
    }
}
