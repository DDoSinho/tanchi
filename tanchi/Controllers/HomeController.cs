using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tanchi.dal.Entities;

namespace Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        public HomeController(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return Ok("/swagger for API  \n" + users.ToList().ToString());
            //return "/swagger for API";
        }
    }
}
