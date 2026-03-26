namespace BaseSmsSending.Application.Features.V1.Products.Commands.CreateProduct;

using BaseSmsSending.Application.Common.Messaging;


public sealed record CreateProductCommand(
    string Name,
    string? Description,
    decimal Price)
    : ICommand<Guid>;
