using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Models.BasketAggregate;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<BasketItem> _basketItemRepository;
        private readonly IAppLogger<BasketService> _logger;
        private readonly IRepository<CatalogItem> _itemRepository;


        public BasketService(IAsyncRepository<Basket> basketRepository,
            IRepository<CatalogItem> itemRepository,
            IAppLogger<BasketService> logger,
            IAsyncRepository<BasketItem> basketItemRepository)
        {
            _basketRepository = basketRepository;
            _logger = logger;
            _itemRepository = itemRepository;
            _basketItemRepository = basketItemRepository;
        }


        public async Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);

            basket.AddItem(catalogItemId, price, quantity);

            await _basketRepository.UpdateAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);

            foreach (var item in basket.Items.ToList())
            {
                await _basketItemRepository.DeleteAsync(item);
            }

            await _basketRepository.DeleteAsync(basket);
        }


        public async Task<int> GetBasketItemCountAsync(string userName)
        {
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            var basketSpec = new BasketWithItemsSpecification(userName);
            var basket = (await _basketRepository.ListAsync(basketSpec)).FirstOrDefault();
            if (basket == null)
            {
                _logger.LogInformation($"No basket found for {userName}");
                return 0;
            }
            int count = basket.Items.Sum(i => i.Quantity);
            _logger.LogInformation($"Basket for {userName} has {count} items.");
            return count;
        }
    }
}
