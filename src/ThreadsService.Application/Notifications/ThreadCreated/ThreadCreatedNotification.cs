using MediatR;

namespace ThreadsService.Application.Notifications.ThreadCreated
{
    public record ThreadCreatedNotification : INotification
    {
        public Guid Id { get; init; }
        public Guid ForumId { get; init; }
        public string TopicName { get; init; }
        public string Content { get; init; }
        public string Author { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastEdited { get; init; }
    }
}
