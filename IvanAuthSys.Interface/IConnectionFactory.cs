using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IvanAuthSys.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
