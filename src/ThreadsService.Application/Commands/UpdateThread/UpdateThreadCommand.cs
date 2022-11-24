using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.UpdateThread
{
    public class UpdateThreadCommand : IRequest<ThreadDto>
    {
        public Guid ExistingId { get; }
        public ThreadDto ExistingThread { get; }

        public UpdateThreadCommand(Guid existingId, ThreadDto existingThread)
        {
            ExistingId = existingId;
            ExistingThread = existingThread;
        }
    }
}
