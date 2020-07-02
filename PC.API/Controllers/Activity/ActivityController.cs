using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using PC.Common;
using PC.IBLL.Activity;
using PC.IBLL.Conferences;
using PC.Model.Models;
using PC.Model.ViewModel;

namespace PC.API.Controllers.Activity
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBll bll;

        public ActivityController(IActivityBll bll)
        {
            this.bll = bll;
        }
        [HttpGet]
        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        public IActionResult ShowActivity(int page = 1, int pageSize = 5,int ActivityType_Id=0,int ActivityState_Id=0,string Search="",int Activity_Product_Id = -1)
        {
            List<ActivityTableModel> list = bll.ShowActivity();
            if (ActivityType_Id!=0)
            {
                list = list.Where(s => s.ActivityType_Id == ActivityType_Id).ToList();
            }
            if (ActivityState_Id != 0)
            {
                list = list.Where(s => s.ActivityState_Id == ActivityState_Id).ToList();
            }
            if (!string.IsNullOrEmpty(Search))
            {
                list = list.Where(s => s.Activity_Name.Contains(Search)).ToList();
            }
            if (Activity_Product_Id != -1)
            {
                list = list.Where(s => s.Activity_Product_Id == Activity_Product_Id).ToList();
            }
            PageModel<ActivityTableModel> model = new PageModel<ActivityTableModel>
            {
                data = list.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                count = list.Count(),
                code = 0,
                msg = ""
            };
            return Ok(model);
        }
        /// <summary>
        ///显示活动类型下拉框
        /// </summary>
        /// <returns></returns>
        public List<ActivityTypeTableModel> ShowType()
        {
            return bll.ShowType();
        }
        /// <summary>
        ///显示活动状态下拉框
        /// </summary>
        /// <returns></returns>
        public List<ActivityStateTableModel> ShowState()
        {
            return bll.ShowState();
        }
        /// <summary>
        ///显示部门下拉框
        /// </summary>
        /// <returns></returns>
        public List<DepartmentTableModel> ShowDep()
        {
            return bll.ShowDep();
        }
        [HttpPost]
        /// <summary>
        ///添加活动
        /// </summary>
        /// <returns></returns>
        public int AddActivity(ActivityTableModel model)
        {
            return bll.AddActivity(model);
        }
        /// <summary>
        ///删除活动
        /// </summary>
        /// <returns></returns>
        public int DelActivity(int id)
        {
            return bll.DelActivity(id);
        }
        /// <summary>
        ///修改活动
        /// </summary>
        /// <returns></returns>
        public int UpdActivity(ActivityTableModel model)
        {
            return bll.UpdActivity(model);
        }
        //public int UpdActivity(string obj)
        //{
        //    ActivityTableModel m = JsonConvert.DeserializeObject<ActivityTableModel>(obj);
        //    return bll.UpdActivity(m);
        //}
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDepartName(int id)
        {

            if (id==0)
            {
                return "";
            }
            return bll.GetDepartName(id);
        }
        /// <summary>
        /// 获取活动类别名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetActivityName(int id)
        {
            if (id == 0)
            {
                return "";
            }
            return bll.GetActivityName(id);
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ActivityTableModel> Details(int id)
        {
            List <ActivityTableModel> list=bll.Details(id);
            return list;
        }
        /// <summary>
        /// 获取执行情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Activity_DoTableModel> Execute(int id)
        {
            List<Activity_DoTableModel> list = bll.Execute(id);
            return list;
        }
        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActivityTableModel GetActivity(int id)
        {
            return bll.GetActivity(id);
        }
        /// <summary>
        /// 显示统计
        /// </summary>
        /// <returns></returns>
        public List<ActivityShowView> ShowView()
        {
            return bll.ShowView();
        }
        /// <summary>
        /// 显示执行的列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ActivityZLY> zLies(int id, int did, int pid, int cid, int dis, string name)
        {
            return bll.zLies(id,did,pid,cid,dis,name);
        }
    }
}