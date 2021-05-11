using OK.Tech.Domain.Apps;
using OK.Tech.Domain.Entities;
using OK.Tech.Domain.Entities.Validations;
using OK.Tech.Domain.Notifications;
using OK.Tech.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OK.Tech.App
{
    public class ProductApp : AppBase, IProductApp
    {
        private readonly IProductRepository _productRepository;

        public ProductApp(IProductRepository productRepository, IUnitOfWork unitOfWork, INotifier notifier) : base(unitOfWork, notifier)
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

        public async Task Create(Product product)
        {
            if (!Validate(new ProductValidation(), product))
            {
                return;
            }

            _productRepository.Create(product);
            await UnitOfWork.Save();
        }

        public async Task Update(Guid id, Product product)
        {
            if (id != product.Id)
            {
                Notify($"The supplied ids {id} and {product.Id} are differents.");
                return;
            }

            if (!Validate(new ProductValidation(), product))
            {
                return;
            }

            var productToUpdate = await GetById(id);

            if (productToUpdate == null)
            {
                Notify($"Product {id} not found.");
                return;
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Active = product.Active;

            _productRepository.Update(productToUpdate);
            await UnitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var productToDelete = await GetById(id);

            if (productToDelete == null)
            {
                Notify($"Product {id} not found.");
                return;
            }

            _productRepository.Delete(productToDelete);
            await UnitOfWork.Save();
        }
    }
}