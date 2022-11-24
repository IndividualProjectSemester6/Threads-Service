using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.CreateThread
{
    public class CreateThreadCommand : IRequest<ThreadDto>
    {
        public ThreadDto Thread { get; }

        public CreateThreadCommand(ThreadDto thread)
        {
            Thread = thread;
        }
    }
}
