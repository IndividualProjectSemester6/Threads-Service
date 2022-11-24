using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.DeleteThread
{
    public class DeleteThreadCommand : IRequest<ThreadDto?>
    {
        public Guid Id { get; }

        public DeleteThreadCommand(Guid id)
        {
            Id = id;
        }
    }
}
