﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC.IBLL.Conferences;
using PC.Model.Models;
using PC.Model.ViewModel;

namespace PC.API.Controllers.Conference
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        public IConferenceBll _bll;
        public ActivityController(IConferenceBll bll)
        {

            _bll = bll;
        }
        /// <summary>
        /// 会议的显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ConferenceShow> ShowConference()
        {
            return _bll.ShowConference();

        }
        /// <summary>
        /// 添加会议
        /// </summary>
        /// <param name="c">要添加的数据</param>
        /// <returns></returns>
        [HttpPost]
        public int AddConference([FromForm]ConferenceTableModel c)
        {
            return _bll.AddConference(c);

        }

    }
}