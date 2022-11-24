using MediatR;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.DeleteThread
{
    public class DeleteThreadHandler : IRequestHandler<DeleteThreadCommand, ThreadDto?>
    {
        private readonly ICommandThreadRepository _repository;

        public DeleteThreadHandler(ICommandThreadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ThreadDto?> Handle(DeleteThreadCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteThread(request.Id);
        }
    }
}
