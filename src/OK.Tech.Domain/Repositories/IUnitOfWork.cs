using System.Threading.Tasks;

namespace OK.Tech.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task<int> Save();
    }
}