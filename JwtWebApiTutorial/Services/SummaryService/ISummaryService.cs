using JwtWebApiTutorial.DTOs.Summary;
using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.Services.SummaryService
{
    public interface ISummaryService
    {
        Task<List<Coin>> GetAll();
        Task<CoinPrice> UpdateCoinPriceBySymbol(string symbol);
        Task<List<CoinPrice>> UpdateAllCoinPrices();
    }
}
