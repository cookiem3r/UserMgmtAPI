using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.Context.Command.CreateJwtToken
{
    public class CreateJwtTokenCommandHandler : IRequestHandler<CreateJwtTokenCommandModel, string>
    {
        private ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public CreateJwtTokenCommandHandler(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

 
        public async Task<string> Handle(CreateJwtTokenCommandModel request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUserByUsername("tommylee");

            return _tokenService.GenerateJwtToken(new User { Id = 1, FirstName = "DAVID", LastName = "LEE", Password = "xxx", Username = "YYY" });
        }
    }
}
