using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;

namespace UserMgmtAPI.Application.UserContext.Command.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandModel, LoginReturn>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserRepository userRepository, IEncryptionService encryptionService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
            _tokenService = tokenService;
        }
        public async Task<LoginReturn> Handle(LoginCommandModel request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);
            if (user == null)
            {
                throw new Exception("Wrong Username");
            }

            byte[] salt = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SALT"));            
            var saltedUserInputPassword = _encryptionService.GenerateSaltedHash(Encoding.ASCII.GetBytes(request.Password), salt);
            var temp = _encryptionService.ByteArrayToString(saltedUserInputPassword);

            //Check if password is correct
            if (Equals(temp, user.SaltedPassword))
            {
                //Generate Token and Refresh Token
                var token = _tokenService.GenerateJwtToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken(user.Username);
                user.RefreshToken = refreshToken;
                //Save the refresh token back into DB
                _userRepository.ReplaceUser(user);

                LoginReturn loginreturn = new LoginReturn { RefreshToken = refreshToken, Token = token };

                return loginreturn;
            }

            else
            {
                throw new Exception("Wrong password");
            }

        }
    }
}
