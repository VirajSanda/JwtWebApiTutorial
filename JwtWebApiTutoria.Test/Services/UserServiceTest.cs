using JwtWebApiTutorial.Models;
using JwtWebApiTutorial.Repository.SummaryRepository;
using JwtWebApiTutorial.Repository.UserRepository;
using JwtWebApiTutorial.Services.SummaryService;
using JwtWebApiTutorial.Services.UserService;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWebApiTutoria.Test.Services
{
    public class UserServiceTest
    {

        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;

        public UserServiceTest()
        {

            _userRepositoryMock = new Mock<IUserRepository>();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            // Configure HttpClient mock
            _httpClient = new HttpClient(httpMessageHandlerMock.Object);

            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetMyName()
        {
            // Arrange
            var userDetails = new UserDetails { Name = "viraj", Email = "viraj@gmail.com", Mobile = "82868212", UserName = "viraj" };
            _userRepositoryMock.Setup(repo => repo.GetMyName()).ReturnsAsync(userDetails);

            // Act
            var result = await _userService.GetMyName();

            // Assert
            Assert.Equal(userDetails, result);
        }

        [Fact]
        public async Task Register()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Test User" };
            _userRepositoryMock.Setup(repo => repo.Register(It.IsAny<User>())).ReturnsAsync(user);

            // Act
            var result = await _userService.Register(user);

            // Assert
            Assert.Equal(user, result);
            _userRepositoryMock.Verify(repo => repo.Register(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task Login()
        {
            // Arrange
            var userDto = new UserDto { Username = "testuser", Password = "password" };
            var user = new User { Id = 1, Name = "Test User" };
            _userRepositoryMock.Setup(repo => repo.Login(It.IsAny<UserDto>())).ReturnsAsync(user);

            // Act
            var result = await _userService.Login(userDto);

            // Assert
            Assert.Equal(user, result);
            _userRepositoryMock.Verify(repo => repo.Login(It.IsAny<UserDto>()), Times.Once);
        }
    }
}
