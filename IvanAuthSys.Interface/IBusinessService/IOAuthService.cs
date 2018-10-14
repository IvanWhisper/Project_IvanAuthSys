using DbEntities;
using IvanAuthSys.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Interface.IBusinessService
{
    public interface IOAuthService
    {
        User VerifyUser(LoginModel loginModel,IQuery query);
    }
}
