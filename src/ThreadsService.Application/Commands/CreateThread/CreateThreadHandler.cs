using MediatR;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.CreateThread
{
    public class CreateThreadHandler : IRequestHandler<CreateThreadCommand, ThreadDto>
    {
        private readonly ICommandThreadRepository _repository;

        public CreateThreadHandler(ICommandThreadRepository repository)
        {
            _repository = repository;
        }

        public Task<ThreadDto> Handle(CreateThreadCommand request, CancellationToken cancellationToken)
        {
            request.Thread.Id = Guid.NewGuid();
            request.Thread.CreatedAt = DateTime.Now;
            request.Thread.LastEdited = DateTime.Now;
            var result = _repository.CreateThread(request.Thread);
            return result;
        }
    }
}
