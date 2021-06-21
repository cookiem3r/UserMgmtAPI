using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(SystemUser user);
        RefreshToken GenerateRefreshToken(string Username);
    }
}
