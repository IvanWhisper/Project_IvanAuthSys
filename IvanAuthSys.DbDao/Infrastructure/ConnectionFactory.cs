using IvanAuthSys.Interface;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace IvanAuthSys.DbDao.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        public static string ConnectionString => "Data Source=127.0.0.1;port=3306;Initial Catalog=ivanauthsys;user id=root;password=abc@123456;Charset=utf8;SslMode = none;";//ConfigurationManager.ConnectionStrings["DTAppCon"].ConnectionString;
        public IDbConnection GetConnections
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                return conn;
            }
        }

        public IDbConnection GetConnection => throw new NotImplementedException();
    }
}
