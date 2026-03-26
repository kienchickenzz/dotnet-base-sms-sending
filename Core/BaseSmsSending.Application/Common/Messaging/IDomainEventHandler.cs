namespace BaseSmsSending.Application.Common.Messaging;

using MediatR;

using BaseSmsSending.Domain.Common;


public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}
