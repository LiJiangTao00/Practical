﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC.MVC.Controllers.Conference
{
    public class ConferenceController : Controller
    {
        //显示页面
        public IActionResult ShowConference()
        {
            return View();

        }
        //添加页面
        public IActionResult AddConference()
        {
            return View();

        }
        //会议统计页面
        public IActionResult ConStatistics()
        {
            return View();

        }
        //显示分配名额页面
        public IActionResult quotaallocation()
        {
            return View();

        }
        //显示修改会议名额页面
        public IActionResult UptQuota()
        {
            return View();

        }
        
    }
}
