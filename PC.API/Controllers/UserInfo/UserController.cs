using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC.IBLL.UserIBLL;
using PC.Model.Models;
using PC.Model.ViewModel;

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
        public int Login(string User_Phone,string User_Pwd)
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
        public List<PlaceTableModel> ShowProvince(int pid=0)
        {
            return _bll.ShowProvince(pid);
        }
        [HttpGet]
        public GetPage<UserShowModel> ShowUser(int product,int did,int pid,int cid,int dis,int jid,string name)
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
        public List<UserShowModel> SelectUser(int id)
        {
            return _bll.SelectUser(id);
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
        [HttpGet]
        public GetPage<JobTableModel> ShowJob(int page,int limit)
        {
            List<JobTableModel> list = _bll.ShowJob();
            List<JobTableModel> linq = _bll.ShowJob().Skip((page-1)*limit).Take(limit).ToList();
            GetPage<JobTableModel> model = new GetPage<JobTableModel>
            {
                code=0,
                msg="",
                Model = linq,
                Total = list.Count()
            };
            return model;
        }
    }
}
