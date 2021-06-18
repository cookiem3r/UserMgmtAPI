
using Autofac;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Infrastructure.Services;

namespace UserMgmtAPI.Infrastructure.Common.Modules
{
    class TokenModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //This is using Autoface way to register
            builder.RegisterType<TokenService>().As<ITokenService>();

            base.Load(builder);
        }
    }
}