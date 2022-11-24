using MediatR;
using ThreadsService.Domain.Entities;

namespace ThreadsService.Application.Commands.CreateThread
{
    public class CreateThreadCommand : IRequest<ThreadDto>
    {
        public string Author { get; }
        public string TopicName { get; }
        public string Content { get; }

        public CreateThreadCommand(string author, string topicName, string content)
        {
            Author = author;
            TopicName = topicName;
            Content = content;
        }
    }
}
