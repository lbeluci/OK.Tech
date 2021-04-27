using OK.Tech.Domain.Entities;
using OK.Tech.Domain.Repositories;
using OK.Tech.Infra.Data.Contexts;

namespace OK.Tech.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext context) : base(context)
        {
        }
    }
}