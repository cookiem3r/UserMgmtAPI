using MediatR;

namespace UserMgmtAPI.Application.UserContext.Command.RefreshTokenCommand
{
    public class RefreshTokenCommandModel: IRequest<string>
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
    }
}
