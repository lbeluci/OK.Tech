using OK.Tech.Domain.Apps;
using OK.Tech.Domain.Entities;
using OK.Tech.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OK.Tech.App
{
    public class ProductApp : IProductApp
    {
        private readonly IProductRepository _productRepository;

        public ProductApp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }
    }
}