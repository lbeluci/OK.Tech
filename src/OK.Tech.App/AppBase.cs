using OK.Tech.Domain.Repositories;

namespace OK.Tech.App
{
    public abstract class AppBase
    {
        public AppBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; }
    }
}