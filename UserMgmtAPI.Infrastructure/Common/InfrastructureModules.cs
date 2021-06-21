using Autofac;
using UserMgmtAPI.Infrastructure.Common.Modules;

namespace UserMgmtAPI.Infrastructure.Common
{
    public class InfrastructureModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new TokenModule());
            builder.RegisterModule(new EncryptionModule());

            base.Load(builder);
        }
    }
}
