using JwtWebApiTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApiTutorial.Services.UserService
{
    public interface IUserService
    {
        Task<UserDetails> GetMyName();
        Task<User> Register(User request);
        Task<User> Login(UserDto request);
    }
}
