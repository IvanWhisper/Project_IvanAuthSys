using DbEntities;
using IvanAuthSys.DbDao.Repositories;
using Newtonsoft.Json;
using System;

namespace DbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DapperRepository<User>();
            string sql = "insert into user(UserID,UserGuid,GroupID,UserName,Password,DateOfBirth,Phone,Email,Address) values(@UserID,@UserGuid,@GroupID,@UserName,@Password,@DateOfBirth,@Phone,@Email,@Address)";
            var u = new User() { UserID = "0001", UserGuid = Guid.NewGuid().ToString(), UserName = "admin", Password = "abc", DateOfBirth = new DateTime(1991, 11, 25), Phone = "12345678912", Email = "123@126.com", Address = "Xxxxxx" };
            db.Add(sql,u,false);
            Console.WriteLine(JsonConvert.SerializeObject(u));
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
