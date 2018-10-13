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
        public bool IsLogin(LoginModel loginModel, IQuery query)
        {
            var user = query.QuerySingle<User>(SqlStr.UserQuery,new User() { UserName=loginModel.UserID});
            return user != null && (user.Password.Equals(loginModel.Password));
        }
    }
}
