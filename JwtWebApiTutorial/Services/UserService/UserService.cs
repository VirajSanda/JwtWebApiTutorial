using JwtWebApiTutorial.Models;
using JwtWebApiTutorial.Repository.SummaryRepository;
using JwtWebApiTutorial.Repository.UserRepository;
using JwtWebApiTutorial.Services.SummaryService;
using System.Security.Claims;

namespace JwtWebApiTutorial.Services.UserService
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDetails> GetMyName()
        {
            var result = await _userRepository.GetMyName();
            return result;
        }
        public async Task<User> Register(User request)
        {
            var result = await _userRepository.Register(request);
            return result;
        }
        public async Task<User> Login(UserDto request)
        {
            var result = await _userRepository.Login(request);
            return result;
        }
    }
}
