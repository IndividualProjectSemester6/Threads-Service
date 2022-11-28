using MassTransit;
using MediatR;
using ThreadsService.Application.Notifications.ThreadCreated;

namespace ThreadsService.Application.Notifications.PostCreated;

public class ThreadCreatedHandler : INotificationHandler<ThreadCreatedNotification>
{
    private readonly ISendEndpointProvider _publisher;

    public ThreadCreatedHandler(ISendEndpointProvider publisher)
    {
        _publisher = publisher;
    }

    public async Task Handle(ThreadCreatedNotification notification, CancellationToken cancellationToken)
    {
        var endpoint = await _publisher.GetSendEndpoint(new Uri("queue:thread-created-queue"));
        await endpoint.Send(new ThreadCreatedNotification()
        {
            Id = notification.Id,
            ForumId = notification.ForumId,
            TopicName = notification.TopicName,
            Content = notification.Content,
            Author = notification.Author,
            CreatedAt = notification.CreatedAt,
            LastEdited = notification.LastEdited
        }, context =>
        {
            context.CorrelationId = notification.ForumId;
        });
    }
}