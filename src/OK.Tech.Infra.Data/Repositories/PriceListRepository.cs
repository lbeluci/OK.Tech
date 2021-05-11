using OK.Tech.Domain.Entities;
using OK.Tech.Domain.Repositories;
using OK.Tech.Infra.Data.Contexts;

namespace OK.Tech.Infra.Data.Repositories
{
    public class PriceListRepository : Repository<PriceList>, IPriceListRepository
    {
        public PriceListRepository(ApiDbContext context) : base(context)
        {
        }
    }
}