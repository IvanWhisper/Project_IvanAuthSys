using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace IvanAuthSys.DbDao.Infrastructure
{
    public static class SqlMapperExtensions
    {
        public static SqlMapper.GridReader GetGridReader<T>(this IDbConnection conn, string sql, object param, IDbTransaction transaction = null)
        {
            return conn.QueryMultiple(sql, param,transaction);
        }
        public static SqlMapper.GridReader GetPage<T>(this IDbConnection conn, string sql, object param, IDbTransaction transaction = null)
        {
            return conn.QueryMultiple(sql, param, transaction);
        }
    }
}
