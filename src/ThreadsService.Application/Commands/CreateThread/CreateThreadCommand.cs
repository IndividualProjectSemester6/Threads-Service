using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.CreateThread
{
    public class CreateThreadCommand : IRequest<ThreadDto>
    {
        public Guid ForumId { get; }
        public string Author { get; }
        public string TopicName { get; }
        public string Content { get; }

        public CreateThreadCommand(Guid forumId, string author, string topicName, string content)
        {
            ForumId = forumId;
            Author = author;
            TopicName = topicName;
            Content = content;
        }
    }
}
