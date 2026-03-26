namespace BaseSmsSending.Application.Features.V1.Products.Commands.DeleteProduct;

using BaseSmsSending.Application.Common.Messaging;


public sealed record DeleteProductCommand(Guid Id) : ICommand<Guid>;
