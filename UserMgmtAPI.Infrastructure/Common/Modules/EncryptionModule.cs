using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgmtAPI.Application.Common.Interfaces;
using UserMgmtAPI.Infrastructure.Services;

namespace UserMgmtAPI.Infrastructure.Common.Modules
{
    class EncryptionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //This is using Autoface way to register
            builder.RegisterType<EncryptionService>().As<IEncryptionService>();

            base.Load(builder);
        }
    }
}
