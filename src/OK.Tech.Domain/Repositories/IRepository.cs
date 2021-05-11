using OK.Tech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OK.Tech.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}