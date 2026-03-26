namespace BaseSmsSending.Application.Common.Messaging;

using MediatR;

using BaseSmsSending.Domain.Common;


public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
