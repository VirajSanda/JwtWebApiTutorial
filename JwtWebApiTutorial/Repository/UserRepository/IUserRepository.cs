using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<UserDetails> GetMyName();
        Task<User> Register(User request);
        Task<User> Login(UserDto request);
    }
}
