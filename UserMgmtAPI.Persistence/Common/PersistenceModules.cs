using Autofac;
using UserMgmtAPI.Persistence.Common.Modules;

namespace UserMgmtAPI.Persistence.Common
{
    public class PersistenceModules: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CosmosDbModule());
            base.Load(builder);
        }
    }
}
