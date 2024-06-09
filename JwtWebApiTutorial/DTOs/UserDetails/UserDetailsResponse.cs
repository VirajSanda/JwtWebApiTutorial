using JwtWebApiTutorial.Models;

namespace JwtWebApiTutorial.DTOs.Summary
{
    public class UserDetailsResponse : BaseResponse
    {
        public UserDetails UserDetails { get; set; }
    }
}
