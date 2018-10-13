using IvanAuthSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvanAuthSys.Dev
{
    public class UserStore
    {
        public static List<LoginModel> loginmodels => new List<LoginModel>() {
            new LoginModel{  UserID="admin",Password="123456" },
            new LoginModel{  UserID="user", Password="123" },
        };
        public UserStore()
        {
            //var db = new DapperRepository<User>();
            //string sql = "insert into user(UserID,UserGuid,GroupID,UserName,Password,DateOfBirth,Phone,Email,Address) values(@UserID,@UserGuid,@GroupID,@UserName,@Password,@DateOfBirth,@Phone,@Email,@Address)";
            //db.Add(sql, new User() { UserID = "0001", UserGuid = Guid.NewGuid().ToString(), UserName = "admin", Password = "abc", DateOfBirth = new DateTime(1991, 11, 25), Phone = "12345678912", Email = "123@126.com", Address = "Xxxxxx" }, false);

        }
    }
}
