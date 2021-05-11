using OK.Tech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OK.Tech.Domain.Apps
{
    public interface IProductApp
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(Guid id);

        Task Create(Product product);

        Task Update(Guid id, Product product);

        Task Delete(Guid id);
    }
}