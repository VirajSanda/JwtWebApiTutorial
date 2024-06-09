using JwtWebApiTutorial.Models;
using JwtWebApiTutorial.Repository.SummaryRepository;

namespace JwtWebApiTutorial.Services.SummaryService
{
    public class SummaryService(ISummaryRepository summaryRepository) : ISummaryService
    {
        private static readonly HttpClient client = new();
        private readonly ISummaryRepository _summaryRepository = summaryRepository;

        public async Task<List<Coin>> GetAll()
        {
            return await _summaryRepository.GetAll();
        }

        public async Task<CoinPrice> UpdateCoinPriceBySymbol(string symbol)
        {
            CoinPrice? coinPrice = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(
                    $"https://api.binance.com/api/v3/ticker/price?symbol={symbol}");
                if (response.IsSuccessStatusCode)
                {
                    coinPrice = await _summaryRepository.UpdateCoinPriceBySymbol(await response.Content.ReadFromJsonAsync<CoinPrice>());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return coinPrice;
        }



        public async Task<List<CoinPrice>> UpdateAllCoinPrices()
        {
            List<CoinPrice> coinPrices = [];
            try
            {

                List<Coin> coins = await _summaryRepository.GetAll();
                foreach (var coin in coins)
                {
                    HttpResponseMessage response = await client.GetAsync(
                        $"https://api.binance.com/api/v3/ticker/price?symbol={coin.Symbol}");
                    if (response.IsSuccessStatusCode)
                    {
                        CoinPrice coinPrice = await response.Content.ReadFromJsonAsync<CoinPrice>();
                        coinPrices.Add(await _summaryRepository.UpdateCoinPriceBySymbol(coinPrice: coinPrice));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return coinPrices;
        }
    }
}
