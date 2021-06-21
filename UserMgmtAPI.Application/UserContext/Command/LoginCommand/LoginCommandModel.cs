using MediatR;

namespace UserMgmtAPI.Application.UserContext.Command.LoginCommand
{
    public class LoginCommandModel : IRequest<LoginReturn>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
