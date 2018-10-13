using DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Interface.IBusinessService
{
    public interface IUserManagerService
    {
        bool RegistUser(User user, IRepository<User> repository);
        bool UpdateUser(User user, IRepository<User> repository);
        bool UnRegistUser(User user, IRepository<User> repository);
    }
}
