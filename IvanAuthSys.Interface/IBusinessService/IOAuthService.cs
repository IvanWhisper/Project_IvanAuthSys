using IvanAuthSys.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Interface.IBusinessService
{
    public interface IOAuthService
    {
        bool IsLogin(LoginModel loginModel,IQuery query);

    }
}
