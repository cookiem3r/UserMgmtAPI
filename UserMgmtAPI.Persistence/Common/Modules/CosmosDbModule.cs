using Autofac;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Persistence.Repository;

namespace UserMgmtAPI.Persistence.Common.Modules
{
    public class CosmosDbModule : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();


            builder.Register(c => new CosmosClient("https://cookiem.documents.azure.com:443/", "jfKoWVmxwV4Zs5lAqQ3gmJZJFjZmoIKAcUbPZ8SiVCZpVX3yzuV8mr8QIHb7qtdKFMmMdiJ3XB1eT3vE1bnzIA==", new CosmosClientOptions
            {
                ApplicationRegion = Regions.EastAsia
            })).AsSelf().SingleInstance(); ;


            //builder.Register(c=> new CosmosClientBuilder("AccountEndpoint=https://cookiem.documents.azure.com:443/;AccountKey=jfKoWVmxwV4Zs5lAqQ3gmJZJFjZmoIKAcUbPZ8SiVCZpVX3yzuV8mr8QIHb7qtdKFMmMdiJ3XB1eT3vE1bnzIA==;")
            //         .WithSerializerOptions(new CosmosSerializationOptions
            //         {
            //             PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            //         })
            //         .Build()).AsSelf().SingleInstance();

            base.Load(builder);
        }
    }
}
