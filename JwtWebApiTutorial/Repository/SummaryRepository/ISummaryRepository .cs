using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.Repository.SummaryRepository
{
    public interface ISummaryRepository
    {
        Task<List<Coin>> GetAll();
        Task<CoinPrice> UpdateCoinPriceBySymbol(CoinPrice coinPrice);
    }
}
