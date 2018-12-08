using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Model
{
    public class RootAppSetting
    {
        public SqlConfig SqlConfigStrs { get; set; }
    }
    public class SqlConfig
    {
        public string MySqlConnectionStr { get; set; }
        public string PsgSqlConnectionStr { get; set; }
    }
}
