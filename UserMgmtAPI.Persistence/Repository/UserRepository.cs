using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Domain.Entities;

namespace UserMgmtAPI.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        private readonly ILogger _logger;

        public UserRepository(CosmosClient cosmosClient, ILogger logger)
        {
            _cosmosClient = cosmosClient;
            var db = _cosmosClient.GetDatabase("TokensDB");
            _container = db.GetContainer("Users");
            _logger = logger;
        }


        public async Task<SystemUser> GetAllItem()
        {
            Container container = _cosmosClient.GetContainer("TokensDB", "Users");
            var response = await container.ReadItemAsync<SystemUser>("1", new PartitionKey("1"));
            return response.Resource;
        }

        public async Task<List<SystemUser>> GetAllUsers()
        {
            var q = _container.GetItemLinqQueryable<SystemUser>();
            var iterator = q.ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.Resource.ToList();
        }

        public async Task<SystemUser> GetUserByUsername(string username)
        {
            var q = _container.GetItemLinqQueryable<SystemUser>();
            var iterator = q.Where(x => x.Username == username).ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.Resource.FirstOrDefault();
        }

        public async void CreateUser(SystemUser user)
        {
            ItemResponse<SystemUser> createNewUserResponse = await _container.CreateItemAsync(user);
            _logger.Information("Rquest Charge: {0} ",createNewUserResponse.RequestCharge);
        }

        public async void ReplaceUser(SystemUser user)
        {
            ItemResponse<SystemUser> response = await _container.ReplaceItemAsync<SystemUser>(user, user.Id, new PartitionKey(user.Id));
            _logger.Information("Rquest Charge: {0} ", response.RequestCharge);
        }

    }
}
