namespace BaseSmsSending.Application.Features.V1.Products.Commands.CreateProduct;

using BaseSmsSending.Application.Common.Messaging;
using BaseSmsSending.Application.Common.ApplicationServices.Persistence;
using BaseSmsSending.Domain.AggregatesModels.Products;
using BaseSmsSending.Domain.Common;


public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(
        IProductRepository productRepository
    )
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(
            request.Name,
            request.Description,
            request.Price);

        var result = await _productRepository.AddAsync(product);

        return result.Id;
    }
}
