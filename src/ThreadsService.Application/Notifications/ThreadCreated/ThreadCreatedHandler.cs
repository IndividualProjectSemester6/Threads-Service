using MassTransit;
using MediatR;
using Shared.Events;

namespace ThreadsService.Application.Notifications.ThreadCreated;

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
        }, context =>
        {
            context.CorrelationId = notification.ForumId;
        });
    }
}