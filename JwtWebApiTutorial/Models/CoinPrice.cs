using JwtWebApiTutorial.DTOs;

namespace JwtWebApiTutorial.Models
{
    public class CoinPrice : BaseEntity
    {
        public string Symbol { get; set; }

        public decimal Price { get; set; }
    }
}
