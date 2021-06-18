using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        string RefreshTokenToken(string refreshToken, string username);
    }
}
