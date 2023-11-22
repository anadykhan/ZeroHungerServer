using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeroHungerVS.Models;
using ZeroHungerVS.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZeroHungerVS.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UsersServices _usersServices;

        public UserController (UsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _usersServices.GetAsync();
        }
        
    }
}

