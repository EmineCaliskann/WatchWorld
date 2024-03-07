﻿
using ApplicationCore.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Web.Extensions;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private HttpContext HttpContext => _httpContextAccessor.HttpContext!;
        private string? UserId => HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        private string? AnonId => HttpContext.Request.Cookies[Constants.BASKET_COOKIE];

        private string BuyerId => UserId ?? AnonId ?? CreateAnonymousId();

        private string _createAnonId = null!;

        private string CreateAnonymousId()
        {
            if(_createAnonId != null) return _createAnonId;
            _createAnonId =Guid.NewGuid().ToString();

            HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIE, _createAnonId, new CookieOptions()
            {
                Expires=DateTime.Now.AddDays(14),
                IsEssential=true
            });
            return _createAnonId;
        }

        public BasketViewModelService(IBasketService basketService,IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async  Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity)
        {
            var basket = await _basketService.AddItemToBasketAsync(BuyerId, productId, quantity);
            return basket.ToBasketViewModel();
        }
    }
}
