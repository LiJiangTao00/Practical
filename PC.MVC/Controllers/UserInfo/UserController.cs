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
        public IActionResult AddSingleUser()
        {
            return View();
        }
        public IActionResult InsertUser()
        {
            return View();
        }
        public IActionResult EditUser()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Test1()
        {
            return View();
        }
    }
}
