using MediatR;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.UserContext.Command.CreateNewUserCommand
{
    public class CreateNewUserCommandHandler: IRequestHandler<CreateNewUserCommandModel,string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        public CreateNewUserCommandHandler(IUserRepository userRepository, IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public async Task<string> Handle(CreateNewUserCommandModel request, CancellationToken cancellationToken)
        {
            var user = new SystemUser { 
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username
            };
            user.Id = Guid.NewGuid().ToString("N");

            byte[] salt  = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SALT"));

            user.SaltedPassword = Encoding.ASCII.GetString(_encryptionService.GenerateSaltedHash(Encoding.ASCII.GetBytes(request.Password), salt));

            _userRepository.CreateUser(user);
            return await Task.FromResult(user.Id);
        }

       
    }
}
