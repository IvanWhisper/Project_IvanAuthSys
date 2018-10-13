using Dapper;
using IvanAuthSys.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvanAuthSys.DbDao.Infrastructure;

namespace IvanAuthSys.DbDao.Repositories
{
    public class DapperQuery : IQuery
    {
        private ILogger log;
        public DapperQuery(ILogger log)
        {
            this.log = log;
        }
        public T QuerySingle<T>(string sql, object paramPairs) where T : class
        {
            return QueryBuild(cn => {
                return cn.Query<T>(sql, paramPairs).SingleOrDefault();
            });
        }
        public IEnumerable<T> QueryList<T>(string sql, object paramPairs) where T : class
        {
            return QueryBuild(cn=> {
                return cn.Query<T>(sql, paramPairs);
            });
        }
        public int Execute(string sql, object paramPairs = null)
        {
            var conn = DataBasePool.getInstance().getConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var result = conn.Execute(sql, paramPairs);
            DataBasePool.getInstance().releaseConnection(conn);
            return result;
        }
        public long Count(string sql, object paramPairs = null)
        {
            var conn = DataBasePool.getInstance().getConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var result =conn.Query<long>(sql, paramPairs).SingleOrDefault();
            DataBasePool.getInstance().releaseConnection(conn);
            return result;
        }
        /// <summary>自动分页，必须带上row_number() over({0}) RowNumber</summary>
        //public Tuple<int, IEnumerable<T>> GetPage<T>(Page page, string sql, object paramPairs = null) where T : class
        //{
        //    var multi = Conn.GetPage<T>(page.PageIndex, page.PageSize, sql, paramPairs);
        //    var count = multi.Read<int>().Single();
        //    var results = multi.Read<T>();
        //    return new Tuple<int, IEnumerable<T>>(count, results);
        //}
        // 需自己实现分页语句
        public Tuple<int, IEnumerable<T>> GetPage<T>(string sql, object paramPairs = null) where T : class
        {
            return null;
        }
        public T QueryBuild<T>(Func<IDbConnection,T> callback) where T : class
        {
            try
            {
                var conn = DataBasePool.getInstance().getConnection();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                var result = callback(conn);
                DataBasePool.getInstance().releaseConnection(conn);
                return result;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }
        public bool IsExist(string sql)
        {
            try {
                var conn = DataBasePool.getInstance().getConnection();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                var result = conn.ExecuteScalar(sql) != null;
                DataBasePool.getInstance().releaseConnection(conn);

                return result;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }
    }
}
