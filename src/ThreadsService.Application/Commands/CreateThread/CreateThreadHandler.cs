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
            var thread = new ThreadDto(Guid.NewGuid(), request.TopicName, request.Content, request.Author, DateTime.UtcNow, DateTime.UtcNow);
            var result = _repository.CreateThread(thread);
            return result;
        }
    }
}
