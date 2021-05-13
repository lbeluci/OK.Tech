using OK.Tech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OK.Tech.Domain.Apps
{
    public interface IApp<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task Create(TEntity entity);

        Task Update(Guid id, TEntity entity);

        Task Delete(Guid id);
    }
}