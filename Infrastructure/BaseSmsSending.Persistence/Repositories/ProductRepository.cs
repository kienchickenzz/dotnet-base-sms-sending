/**
 * Repository implementation for Product aggregate.
 *
 * <p>Inherits all CRUD operations from base Repository.
 * Add domain-specific query methods here if needed.</p>
 */
namespace BaseSmsSending.Persistence.Repositories;

using BaseSmsSending.Application.Common.ApplicationServices.Persistence;
using BaseSmsSending.Domain.AggregatesModels.Products;
using BaseSmsSending.Persistence.Common;
using BaseSmsSending.Persistence.DatabaseContext;


public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
