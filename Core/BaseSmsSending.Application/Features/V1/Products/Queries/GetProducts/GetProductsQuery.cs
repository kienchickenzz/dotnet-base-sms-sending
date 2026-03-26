namespace BaseSmsSending.Application.Features.V1.Products.Queries.GetProducts;

using BaseSmsSending.Application.Common.Messaging;
using BaseSmsSending.Application.Common.Models;
using BaseSmsSending.Application.Features.V1.Products.Models;


public sealed class GetProductsQuery : PaginationFilter, IQuery<PaginationResponse<ProductResponse>>
{
}
