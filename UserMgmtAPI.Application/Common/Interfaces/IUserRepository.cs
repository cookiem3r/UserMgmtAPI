using System.Collections.Generic;
using System.Threading.Tasks;
using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAllItem();

        Task<List<User>> GetAllUsers();

        Task<User> GetUserByUsername(string username);
    }
}
