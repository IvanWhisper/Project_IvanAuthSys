using Autofac;
using IvanAuthSys.Interface.IBusinessService;
using IvanAuthSys.Service.BusinessService;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Service
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OAuthService>().As<IOAuthService>().SingleInstance();
            builder.RegisterType<UserManagerService>().As<IUserManagerService>().SingleInstance();

        }
    }
}
