using Autofac;
using Microsoft.Azure.Cosmos;
using System;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Persistence.Repository;

namespace UserMgmtAPI.Persistence.Common.Modules
{
    public class CosmosDbModule : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            var url = Environment.GetEnvironmentVariable("DATABASEURL");
            var key = Environment.GetEnvironmentVariable("DATABASEKEY");


            builder.Register(c => new CosmosClient(url, key, new CosmosClientOptions
            {
                ApplicationRegion = Regions.EastAsia
            })).AsSelf().SingleInstance();

            base.Load(builder);
        }
    }
}
