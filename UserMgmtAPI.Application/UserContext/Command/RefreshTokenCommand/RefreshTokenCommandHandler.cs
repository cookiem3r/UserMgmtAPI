using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;

namespace UserMgmtAPI.Application.UserContext.Command.RefreshTokenCommand
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandModel, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<string> Handle(RefreshTokenCommandModel request, CancellationToken cancellationToken)
        {
            //Get user from DB
            var user = await _userRepository.GetUserByUsername(request.Username);
            if (user!=null)
            {
                //Check if RefreshToken is valid
                if (user.RefreshToken.Token == request.RefreshToken)
                {

                    //Return Id Token
                    return _tokenService.GenerateJwtToken(user);
                }
            }

            throw new System.Exception("Something went wrong. Either wrong refresh token or username");
        }
    }
}
