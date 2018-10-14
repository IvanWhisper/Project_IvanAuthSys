using DbEntities;
using IvanAuthSys.Interface;
using IvanAuthSys.Interface.IBusinessService;
using IvanAuthSys.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Service.BusinessService
{
    public class OAuthService : IOAuthService
    {
        private ILogger _log;
        public OAuthService(ILogger log)
        {
            _log = log;
        }
        public User VerifyUser(LoginModel loginModel, IQuery query)
        {
            var user = query.QuerySingle<User>(SqlStr.UserQuery,new User() { UserID=loginModel.UserID});
            return user;
        }
    }
}
