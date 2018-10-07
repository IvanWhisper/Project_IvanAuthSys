using System;

namespace IvanAuthSys.DbDao
{
    public class SqlStr
    {
        public static string CreateUsers => "Create Table User(UserID varchar(20) not null primary key,UserGuid varchar(255),GroupID varchar(20),UserName varchar(10),Password varchar(20),DateOfBirth datetime,Phone varchar(11),Email varchar(50),Address varchar(255))";

    }
}
