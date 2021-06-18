using Autofac;
using Microsoft.Azure.Cosmos;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Persistence.Repository;

namespace UserMgmtAPI.Persistence.Common.Modules
{
    public class CosmosDbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();


            builder.Register(c => new CosmosClient("https://cookiem.documents.azure.com:443/", "jfKoWVmxwV4Zs5lAqQ3gmJZJFjZmoIKAcUbPZ8SiVCZpVX3yzuV8mr8QIHb7qtdKFMmMdiJ3XB1eT3vE1bnzIA==", new CosmosClientOptions
            { 
                ApplicationRegion = Regions.EastAsia
            })).AsSelf();

            base.Load(builder);
        }
    }
}
