using Autofac;
using IvanAuthSys.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Logger
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new LoggerConsole()).Keyed<ILogger>("console").SingleInstance();
            builder.Register(c => new LoggerNLog()).Keyed<ILogger>("nlog").SingleInstance();
        }
    }
}
