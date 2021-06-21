using System.Collections.Generic;
using System.Threading.Tasks;
using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<SystemUser> GetAllItem();

        Task<List<SystemUser>> GetAllUsers();

        Task<SystemUser> GetUserByUsername(string username);

        void CreateUser(SystemUser user);

        void ReplaceUser(SystemUser user);
    }
}
