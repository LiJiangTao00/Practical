using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC.MVC.Controllers.Activity
{
    public class ActivityController : Controller
    {
        public IActionResult ShowActivity()
        {
            return View();
        }
        public IActionResult AddActivity()
        {
            return View();
        }
        public IActionResult UpdActivity()
        {
            return View();
        }
        public IActionResult Details(int id=-1)
        {
            ViewBag.show = id;
            return View();
        }
        public IActionResult Execute()
        {
            return View();
        }
    }
}