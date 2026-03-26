namespace BaseSmsSending.Application.Features.V1.Products.Commands.UpdateProduct;

using BaseSmsSending.Application.Common.Messaging;
using BaseSmsSending.Application.Common.ApplicationServices.Persistence;
using BaseSmsSending.Domain.AggregatesModels.Products;
using BaseSmsSending.Domain.Common;


public sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(
        IProductRepository productRepository
    )
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Result.Failure<Guid>(ProductErrors.NotFound);

        // Update price only if it actually changed
        if (request.Price != product.Price)
        {
            product.UpdatePrice(request.Price);
        }

        // Prepare values for UpdateDetails
        string name = request.Name ?? product.Name;
        string? description = request.Description ?? product.Description;

        product.UpdateDetails(name, description);

        await _productRepository.UpdateAsync(product, cancellationToken);

        return product.Id;
    }
}
