using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.DTOs.Token
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }
    }
}
