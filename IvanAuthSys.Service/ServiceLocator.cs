using Autofac;
using System;

namespace IvanAuthSys.Service
{
    public class ServiceLocator
    {
        public static IContainer ApplicationContainer { get; private set; }
        static ServiceLocator()
        {
            var builder = new ContainerBuilder();

            ApplicationContainer = builder.Build();
        }
    }
}
