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
        public List<UserShowModel> ShowUser(int did,int pid,int cid,int dis,int jid,string name)
        {
            return _bll.ShowUser(did,pid,cid,dis,jid,name);
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
    }
}
