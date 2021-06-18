using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;

namespace UserMgmtAPI.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public UserRepository(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;

            var db = _cosmosClient.GetDatabase("TokensDB");
            _container = db.GetContainer("Users");
        }


        public async Task<Domain.Entities.User> GetAllItem()
        {
            Container container = _cosmosClient.GetContainer("TokensDB", "Users");
            var response = await container.ReadItemAsync<Domain.Entities.User>("1", new PartitionKey("1"));
            return response.Resource;
        }

        public async Task<List<Domain.Entities.User>> GetAllUsers()
        {
            var q = _container.GetItemLinqQueryable<Domain.Entities.User>();
            var iterator = q.ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.Resource.ToList();
        }

        public async Task<Domain.Entities.User> GetUserByUsername(string username)
        {
            var q = _container.GetItemLinqQueryable<Domain.Entities.User>();
            var iterator = q.Where(x=>x.Username == username).ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.Resource.FirstOrDefault();
        }

    }
}
