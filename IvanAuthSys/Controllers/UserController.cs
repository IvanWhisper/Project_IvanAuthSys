using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DbEntities;
using IvanAuthSys.Interface;
using IvanAuthSys.Interface.IBusinessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IvanAuthSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILifetimeScope _rootScope;
        ILogger _log;
        IUserManagerService _userManagerService;
        public UserController(ILogger log, ILifetimeScope rootScope, IUserManagerService userManagerService)
        {
            _log = log;
            _userManagerService = userManagerService;
            _rootScope = rootScope;
        }
        // GET: api/User
        [HttpGet]
        public string Get()
        {
            return "userModule";
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User value)
        {
            using (var scope =_rootScope.BeginLifetimeScope())
            {
                _userManagerService.RegistUser(value, scope.Resolve<IRepository<User>>());

            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
