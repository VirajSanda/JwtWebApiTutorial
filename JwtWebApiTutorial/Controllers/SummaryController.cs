using JwtWebApiTutorial.DTOs.Summary;
using JwtWebApiTutorial.Models;
using JwtWebApiTutorial.Services.SummaryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApiTutorial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SummaryController(ISummaryService summaryService) : ControllerBase
    {
        private readonly ISummaryService _summaryService = summaryService;

        [HttpGet, Authorize]
        public async Task<CoinResponse> GetAll()
        {
            CoinResponse coinResponse = new();
            try
            {
                var coins = await _summaryService.GetAll();
                coinResponse.Coins = coins;
                coinResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                coinResponse.IsSuccess = false;
                coinResponse.Message = ex.Message;
            }
            return coinResponse;
        }

        [HttpGet, Authorize]
        public async Task<CoinPriceResponse> UpdateCoinPriceBySymbol(string symbol)
        {
            CoinPriceResponse coinPriceResponse = new();
            CoinPrice coinPrice = await _summaryService.UpdateCoinPriceBySymbol(symbol);
            if (coinPrice != null)
            {
                coinPriceResponse.CoinPrice = coinPrice;
                coinPriceResponse.IsSuccess = true;
                coinPriceResponse.LastAccessedDateTime = DateTime.Now;
            }
            return coinPriceResponse;
        }

        [HttpGet, Authorize]
        public async Task<CoinPriceResponse> UpdateAllCoinPrices()
        {
            CoinPriceResponse coinPriceResponse = new();
            List<CoinPrice> coinPrice = await _summaryService.UpdateAllCoinPrices();
            if (coinPrice != null)
            {
                coinPriceResponse.IsSuccess = true;
                coinPriceResponse.LastAccessedDateTime = DateTime.Now;
            }
            return coinPriceResponse;
        }
    }
}
