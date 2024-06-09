using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.DTOs.Summary
{
    public class CoinResponse : BaseResponse
    {
        public List<Coin> Coins { get; set; }
    }
}
