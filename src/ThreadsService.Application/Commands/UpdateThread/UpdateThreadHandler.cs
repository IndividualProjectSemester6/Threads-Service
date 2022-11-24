using MediatR;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.UpdateThread
{
    public class UpdateThreadHandler : IRequestHandler<UpdateThreadCommand, ThreadDto?>
    {
        private readonly ICommandThreadRepository _repository;

        public UpdateThreadHandler(ICommandThreadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ThreadDto?> Handle(UpdateThreadCommand request, CancellationToken cancellationToken)
        {
            request.ExistingThread.Id = request.ExistingId;
            request.ExistingThread.LastEdited = DateTime.UtcNow;
            return await _repository.UpdateThread(request.ExistingThread);
        }
    }
}
