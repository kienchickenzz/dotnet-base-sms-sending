namespace BaseSmsSending.Application.Common.Messaging;

using BaseSmsSending.Domain.Common;

using MediatR;


public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
