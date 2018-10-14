using Autofac;
using DbEntities;
using IvanAuthSys.DbDao.Repositories;
using IvanAuthSys.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.DbDao
{
    public class DbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DapperRepository<User>()).As<IRepository<User>>().InstancePerLifetimeScope();
            builder.RegisterType<DapperQuery>().As<IQuery>().InstancePerLifetimeScope();
        }
    }

}
