using DbEntities;
using IvanAuthSys.Interface;
using IvanAuthSys.Interface.IBusinessService;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Service.BusinessService
{
    public class UserManagerService: IUserManagerService
    {
        private ILogger _log;
        public UserManagerService(ILogger log)
        {
            _log = log;
        }
        public bool RegistUser(User user, IRepository<User> repository)
        {
            bool result = false;
            try
            {
                if (user == null || repository == null)
                    return false;
                result = repository.Add(SqlStr.UserAdd, user, false) > 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return result;
        }
        public bool UpdateUser(User user, IRepository<User> repository)
        {
            bool result = false;
            try
            {
                if (user == null || repository == null)
                    return false;
                result = repository.Update(SqlStr.UserUpdate, user, false) > 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return result;
        }
        public bool UnRegistUser(User user, IRepository<User> repository)
        {
            bool result = false;
            try
            {
                if (user == null || repository == null)
                    return false;
                result = repository.Delete(SqlStr.UserDelete, user, false) > 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return result;

        }
    }
}
