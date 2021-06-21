using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.UserContext.Command.LoginCommand
{
    public class LoginReturn
    {
        public string Token { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
