namespace BaseSmsSending.Domain.AggregatesModels.Products;

using BaseSmsSending.Domain.Common;


public static class ProductErrors
{
    public static Error NotFound = new(
        "Product.NotFound",
        "Product not found!");
}
