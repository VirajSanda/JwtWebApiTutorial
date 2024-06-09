using JwtWebApiTutorial.Models;
using JwtWebApiTutorial.Repository.SummaryRepository;
using JwtWebApiTutorial.Services.SummaryService;
using System.Net.Http.Json;
using System.Net;
using Moq;
using Moq.Protected;

namespace JwtWebApiTutoria.Test.Services
{
    public class SummaryServiceTest
    {

        private readonly Mock<ISummaryRepository> _summaryRepositoryMock;
        private readonly HttpClient _httpClient;
        private readonly SummaryService _summaryService;

        public SummaryServiceTest()
        {
            _summaryRepositoryMock = new Mock<ISummaryRepository>();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            // Configure HttpClient mock
            _httpClient = new HttpClient(httpMessageHandlerMock.Object);

            _summaryService = new SummaryService(_summaryRepositoryMock.Object);
           
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllCoins()
        {
            // Arrange
            var coins = new List<Coin> { new() { Symbol = "BTC" }, new() { Symbol = "ETH" } };
            _summaryRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(coins);

            // Act
            var result = await _summaryService.GetAll();

            // Assert
            Assert.Equal(coins, result);
        }

        [Fact]
        public async Task UpdateCoinPriceBySymbol_ShouldReturnUpdatedCoinPrice()
        {
            // Arrange
            var symbol = "BTCUSDT";
            var coinPrice = new CoinPrice { Symbol = symbol, Price = 50000 };

            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(coinPrice)
            };

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
            )
                .ReturnsAsync(responseMessage);

            _summaryRepositoryMock.Setup(repo => repo.UpdateCoinPriceBySymbol(It.IsAny<CoinPrice>()))
                                  .ReturnsAsync(coinPrice);

            // Act
            var result = await _summaryService.UpdateCoinPriceBySymbol(symbol);

            // Assert
            Assert.Equal(coinPrice, result);
        }

        [Fact]
        public async Task UpdateAllCoinPrices_ShouldReturnAllUpdatedCoinPrices()
        {
            // Arrange
            var coins = new List<Coin> { new() { Symbol = "BTCUSDT" }, new() { Symbol = "ETHUSDT" } };
            var coinPrices = new List<CoinPrice>
        {
            new() { Symbol = "BTCUSDT", Price = 50000 },
            new() { Symbol = "ETHUSDT", Price = 3000 }
        };

            _summaryRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(coins);

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            httpMessageHandlerMock.Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(coinPrices[0])
                })
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(coinPrices[1])
                });

            _summaryRepositoryMock.Setup(repo => repo.UpdateCoinPriceBySymbol(It.IsAny<CoinPrice>()))
                                  .ReturnsAsync((CoinPrice cp) => cp);

            // Act
            var result = await _summaryService.UpdateAllCoinPrices();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
