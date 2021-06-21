using MediatR;
using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.UserContext.Command.CreateNewUserCommand
{
    public class CreateNewUserCommandModel : IRequest<string>
    {
        public SystemUser User { get; set; }
    }
}
