using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.UpdateThread
{
    public class UpdateThreadCommand : IRequest<ThreadDto>
    {
        public ThreadDto ExistingThread { get; }

        public UpdateThreadCommand(ThreadDto existingThread)
        {
            ExistingThread = existingThread;
        }
    }
}
