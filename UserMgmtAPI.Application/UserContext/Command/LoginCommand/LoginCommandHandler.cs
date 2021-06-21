using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UserMgmtAPI.Application.UserContext.Command.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandModel, string>
    {
        public Task<string> Handle(LoginCommandModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
