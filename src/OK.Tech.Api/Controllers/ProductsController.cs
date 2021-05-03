using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OK.Tech.Api.Models;
using OK.Tech.Domain.Apps;
using OK.Tech.Domain.Entities;
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

        public ProductsController(IProductApp productApp, IMapper mapper)
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
        public ActionResult<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                CustomResponse(ModelState, productViewModel);
            }

            _productApp.Create(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        [HttpPut("{id:Guid}")]
        public ActionResult<ProductViewModel> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                CustomResponse(ModelState, productViewModel);
            }

            //Atualização do produto

            return CustomResponse(productViewModel);
        }

        [HttpDelete]
        public ActionResult<ProductViewModel> DeleteProduct(Guid id)
        {
            _productApp.Delete(id);

            return CustomResponse();
        }
    }
}