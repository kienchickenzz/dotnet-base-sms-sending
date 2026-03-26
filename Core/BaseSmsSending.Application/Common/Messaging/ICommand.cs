namespace BaseSmsSending.Application.Common.Messaging;

using MediatR;

using BaseSmsSending.Domain.Common;


public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
