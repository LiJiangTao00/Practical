using System;
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
    public class ConferenceController : ControllerBase
    {
        public IConferenceBll _bll;
        public ConferenceController(IConferenceBll bll)
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

        [HttpPost]

        public SearchPageShowConference SearchConference([FromForm] SearchPageConference spc)
        {

            return _bll.SearchConference(spc.condate, spc.conplace, spc.constate, spc.conname, spc.conproduct, spc.pageindex, spc.pagesize);

        }
        /// <summary>
        /// 添加会议
        /// </summary>
        /// <param name="c">要添加的数据</param>
        /// <returns></returns>
        [HttpPost]
        public int AddConference([FromForm]ConferenceTableModel con)
        {
            return _bll.AddConference(con);

        }

        [HttpGet]
        //删除会议
        public int DelConference(string ids)
        {
            return _bll.DelConference(ids);
        }

        //会议详情（根据ID反填）
        [HttpGet]
        public ConferenceInfo ConferenceInfo(int cid)
        {
            return _bll.ConferenceInfo(cid);
        }
        //会议统计 即根据条件查询会议数量
        [HttpGet]
        public ConNums ConStatistics(string conproduct, int conyear = -1, int departmentid = -1, int con_typeid = -1)
        {
            return _bll.ConStatistics(conproduct, conyear, departmentid, con_typeid);
        }
        //会议统计页面的部门下拉菜单
        [HttpGet]
        public List<DepartmentTableModel> DepSel()
        {

            return _bll.DepSel();
        }

        //会议统计页面的会议类型下拉菜单
        [HttpGet]
        public List<ConferenceTypeTableModel> ConTypeSel()
        {

            return _bll.ConTypeSel();
        }
    }
}