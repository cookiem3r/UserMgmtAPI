using MediatR;

namespace UserMgmtAPI.Application.UserContext.Command.CreateNewUserCommand
{
    public class CreateNewUserCommandModel : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
