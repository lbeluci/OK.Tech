using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OK.Tech.Api.Models;
using OK.Tech.Domain.Apps;
using OK.Tech.Domain.Entities;
using OK.Tech.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OK.Tech.Api.Controllers
{
    [Route("products")]
    public class ProductsController : MainController
    {
        private readonly IProductApp _productApp;
        private readonly IMapper _mapper;

        public ProductsController(IProductApp productApp, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _productApp = productApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            return CustomResponse(_mapper.Map<IEnumerable<ProductViewModel>>(await _productApp.GetAll()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById(Guid id)
        {
            return CustomResponse(_mapper.Map<ProductViewModel>(await _productApp.GetById(id)));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            if (!IsModelValid())
            {
                return CustomResponse(productViewModel);
            }

            await _productApp.Create(_mapper.Map<Product>(productViewModel));

            return CustomResponse();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            if (!IsModelValid())
            {
                return CustomResponse(productViewModel);
            }

            await _productApp.Update(id, _mapper.Map<Product>(productViewModel));

            return CustomResponse();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _productApp.Delete(id);

            return CustomResponse();
        }
    }
}