using JwtWebApiTutorial.DTOs;

namespace JwtWebApiTutorial.Models
{
    public class Coin : BaseEntity
    {
        public int Id { get; set; }
        public required string Symbol { get; set; }

        public decimal Filled { get; set; }

        public decimal Total { get; set; }

        public decimal Price { get; set; }

        public string? Name { get; set; }

        public DateTime Date { get; set; }

        public decimal LastTotal { get; set; }
        public DateTime LastChecked { get; set; }
        public decimal TotalDefference { get; set; }
        public decimal TotalDiffPrecentage { get; set; }
    }
}
