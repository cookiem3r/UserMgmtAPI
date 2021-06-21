using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;

namespace UserMgmtAPI.Application.UserContext.Command.CreateNewUserCommand
{
    public class CreateNewUserCommandHandler: IRequestHandler<CreateNewUserCommandModel,string>
    {
        private readonly IUserRepository _userRepository;

        public CreateNewUserCommandHandler(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateNewUserCommandModel request, CancellationToken cancellationToken)
        {
            request.User.Id = Guid.NewGuid().ToString("N");
            _userRepository.CreateUser(request.User);
            return await Task.FromResult(request.User.Id.ToString());
        }
    }
}
