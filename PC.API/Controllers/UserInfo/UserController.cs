using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC.IBLL.UserIBLL;
using PC.Model.Models;
using PC.Model.ViewModel;
using Newtonsoft.Json;
using PC.Common.Helpers;
using PublicToolsLib.HelpExcel;

namespace PC.API.Controllers.UserInfo
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUBLL _bll;
        public UserController(IUBLL bll)
        {
            _bll = bll;
        }
        [HttpGet]
        public int Login(string User_Phone, string User_Pwd)
        {
            return _bll.Login(User_Phone, User_Pwd);
        }
        [HttpPut]
        public int Forget(UserTableModel m)
        {
            return _bll.Forget(m);
        }
        [HttpGet]
        public string SelectName(string User_Phone)
        {
            return _bll.SelectName(User_Phone);
        }
        [HttpGet]
        public List<DepartmentTableModel> ShowDepartment()
        {
            return _bll.ShowDepartment();
        }
        [HttpGet]
        public List<PlaceTableModel> ShowProvince(int pid = 0)
        {
            return _bll.ShowProvince(pid);
        }
        [HttpGet]
        public GetPage<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name)
        {
            List<UserShowModel> list = _bll.ShowUser(product, did, pid, cid, dis, jid, name);
            GetPage<UserShowModel> page = new GetPage<UserShowModel>
            {
                Model = list,
                Total = list.Count()
            };
            return page;
        }
        [HttpGet]
        public UserShowModel SelectUser(int id)
        {
            return _bll.SelectUser(id).FirstOrDefault();
        }
        [HttpGet]
        public List<JobTableModel> ShowJob()
        {
            return _bll.ShowJob();
        }
        [HttpPost]
        public int AddSingleUser(UserTableModel m)
        {
            return _bll.AddSingleUser(m);
        }
        //[HttpGet]
        //public GetPage<JobTableModel> ShowJob(int page,int limit)
        //{
        //    List<JobTableModel> list = _bll.ShowJob();
        //    List<JobTableModel> linq = _bll.ShowJob().Skip((page-1)*limit).Take(limit).ToList();
        //    GetPage<JobTableModel> model = new GetPage<JobTableModel>
        //    {
        //        code=0,
        //        msg="",
        //        Model = linq,
        //        Total = list.Count()
        //    };
        //    return model;
        //}
        [HttpDelete]
        public int DelUser(string id)
        {
            if (!id.Contains(','))
            {
                return _bll.DelSingleUser(int.Parse(id));
            }
            else
            {
                string[] pid = id.Split(',');
                int i = 0;
                foreach (string cid in pid)
                {
                    i = _bll.DelSingleUser(int.Parse(cid));
                }
                if (i == pid.Length)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        [HttpPost]
        public void PutOut([FromBody] string path)
        {
            DataTable tb = _bll.ShowUser();
            OledbExcelHelper.DataTableToExcel(path, tb);
        }
        [HttpGet]
        public List<UserShowModel> SelectSomeUser(string id)
        {
            if (!id.Contains(','))
            {
                return _bll.SelectUser(int.Parse(id));
            }
            else
            {
                string[] pid = id.Split(',');
                string ids = " where ";
                foreach (string cid in pid)
                {
                    ids += " u.Id =" + int.Parse(cid) + " or";
                }
                ids = ids.Substring(0, (ids.Length - 2));
                return _bll.ShowSome(ids);
            }
        }
        [HttpGet]
        public int UpdateSome(string gid, int sid, string desc, string action)
        {
            return _bll.UpdateSome(gid, sid, action);
        }
        [HttpPut]
        public int UpdateSingleUser(UserTableModel m)
        {
            return _bll.UpdateSingleUser(m);
        }
    }
}
