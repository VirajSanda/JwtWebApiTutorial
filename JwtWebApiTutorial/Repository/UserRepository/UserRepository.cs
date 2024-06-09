using Azure.Core;
using Dapper;
using JwtWebApiTutorial.Data;
using JwtWebApiTutorial.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using static System.Data.CommandType;

namespace JwtWebApiTutorial.Repository.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Const
        private const string SP_INSERT_USER = "[dbo].[Insert_User]";
        private const string SP_SELECT_USER_BY_USERNAME = "[dbo].[Select_UserByUsername]";
        #endregion

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDetails> GetMyName()
        {
            UserDetails userDetails = new();
            if (_httpContextAccessor.HttpContext != null)
            {
                userDetails.Name = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return userDetails;
        }

        public async Task<User> Register(User request)
        {
            DynamicParameters parameters = new();
            parameters.Add("@UserVM", JsonConvert.SerializeObject(request));
            User user = SqlMapper.Query<User>(con, SP_INSERT_USER, parameters, commandType: StoredProcedure).FirstOrDefault();

            return user;
        }


        public async Task<User> Login(UserDto request)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Username", request.Username);
            User user = SqlMapper.Query<User>(con, SP_SELECT_USER_BY_USERNAME, parameters, commandType: StoredProcedure).FirstOrDefault();

            return user;
        }
    }
}
