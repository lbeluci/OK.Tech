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
    public class PriceListApp : AppBase, IPriceListApp
    {
        private readonly IPriceListRepository _priceListRepository;

        public PriceListApp(IPriceListRepository priceListRepository, IUnitOfWork unitOfWork, INotifier notifier) : base(unitOfWork, notifier)
        {
            _priceListRepository = priceListRepository;
        }

        public async Task<IEnumerable<PriceList>> GetAll()
        {
            return await _priceListRepository.GetAll();
        }

        public async Task<PriceList> GetById(Guid id)
        {
            return await _priceListRepository.GetById(id);
        }

        public async Task Create(PriceList priceList)
        {
            if (!Validate(new PriceListValidation(), priceList))
            {
                return;
            }

            _priceListRepository.Create(priceList);
            await UnitOfWork.Save();
        }

        public async Task Update(Guid id, PriceList priceList)
        {
            if (id != priceList.Id)
            {
                Notify($"The supplied ids {id} and {priceList.Id} are differents.");
                return;
            }

            if (!Validate(new PriceListValidation(), priceList))
            {
                return;
            }

            var priceListToUpdate = await GetById(id);

            if (priceListToUpdate == null)
            {
                Notify($"Price List {id} not found.");
                return;
            }

            priceListToUpdate.Name = priceList.Name;
            priceListToUpdate.Active = priceList.Active;

            _priceListRepository.Update(priceListToUpdate);
            await UnitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var priceListToDelete = await GetById(id);

            if (priceListToDelete == null)
            {
                Notify($"Price List {id} not found.");
                return;
            }

            _priceListRepository.Delete(priceListToDelete);
            await UnitOfWork.Save();
        }
    }
}