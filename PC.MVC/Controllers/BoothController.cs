﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC.MVC.Controllers
{
    public class BoothController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
