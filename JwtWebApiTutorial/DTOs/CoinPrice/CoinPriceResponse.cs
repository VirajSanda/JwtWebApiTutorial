using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.DTOs.Summary
{
    public class CoinPriceResponse : BaseResponse
    {
        public CoinPrice CoinPrice { get; set; }
    }
}
