namespace BaseSmsSending.Application.Features.V1.Products.Queries.GetProductById;

using BaseSmsSending.Application.Common.Messaging;
using BaseSmsSending.Application.Features.V1.Products.Models;


public sealed record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
