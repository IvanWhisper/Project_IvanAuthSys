using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Service
{
    public class SqlStr
    {
        public static string UserQuery = "select * from user where UserID=@UserID";
        public static string UserAdd = "insert into user(UserID,UserGuid,GroupID,UserName,Password,DateOfBirth,Phone,Email,Address) values(@UserID,@UserGuid,@GroupID,@UserName,@Password,@DateOfBirth,@Phone,@Email,@Address)";
        public static string UserUpdate = "update user set UserGuid=@UserGuid,GroupID=@GroupID,UserName=@UserName,Password=@Password,DateOfBirth=@DateOfBirth,Phone=@Phone,Email=@Email,Address=@Address where UserID=@UserID";
        public static string UserDelete = "Delete from user where UserID=@UserID";

    }
}
