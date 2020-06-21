using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC.MVC.Controllers.UserInfo
{
    public class UserController : Controller
    {
        public IActionResult ShowList()
        {
            return View();
        }
        public IActionResult ShowJob()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }
    }
}
