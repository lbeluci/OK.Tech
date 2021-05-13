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
    [Route("pricelists")]
    public class PriceListController : MainController
    {
        private readonly IPriceListApp _priceListApp;
        private readonly IMapper _mapper;

        public PriceListController(IPriceListApp priceListApp, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _priceListApp = priceListApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceListViewModel>>> GetPriceLists()
        {
            return CustomResponse(_mapper.Map<IEnumerable<PriceListViewModel>>(await _priceListApp.GetAll()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PriceListViewModel>> GetPriceListById(Guid id)
        {
            return CustomResponse(_mapper.Map<PriceListViewModel>(await _priceListApp.GetById(id)));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePriceList(PriceListViewModel priceListViewModel)
        {
            if (!IsModelValid())
            {
                return CustomResponse(priceListViewModel);
            }

            await _priceListApp.Create(GetMappedPriceList(priceListViewModel));

            return CustomResponse();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdatePriceList(Guid id, PriceListViewModel priceListViewModel)
        {
            if (!IsModelValid())
            {
                return CustomResponse(priceListViewModel);
            }

            await _priceListApp.Update(id, GetMappedPriceList(priceListViewModel));

            return CustomResponse();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeletePriceList(Guid id)
        {
            await _priceListApp.Delete(id);

            return CustomResponse();
        }

        private PriceList GetMappedPriceList(PriceListViewModel priceListViewModel)
        {
            return _mapper.Map<PriceList>(priceListViewModel);
        }
    }
}