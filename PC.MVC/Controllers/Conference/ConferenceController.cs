using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC.MVC.Controllers.Conference
{
    public class ConferenceController : Controller
    {
        public IActionResult ShowConference()
        {
            return View();

        }
    }
}
