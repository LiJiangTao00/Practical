using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC.IBLL.Conferences;
using PC.Model.ViewModel;

namespace PC.API.Controllers.Conference
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        public IConferenceBll _bll;
        public ConferenceController(IConferenceBll bll)
        {

            _bll = bll;
        }
        [HttpGet]
        public List<ConferenceShow> ShowConference()
        {
            return _bll.ShowConference();

        }



    }
}