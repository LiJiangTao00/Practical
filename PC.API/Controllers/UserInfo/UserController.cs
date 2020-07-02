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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PC.API.Controllers.UserInfo
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IWebHostEnvironment _hostEnvironment;
        private IUBLL _bll;
        public UserController(IUBLL bll, IWebHostEnvironment hostEnvironment)
        {
            _bll = bll;
            _hostEnvironment = hostEnvironment;
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
        public GetPage<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name,int index=1,int size=3)
        {
            List<UserShowModel> list = _bll.ShowUser(product, did, pid, cid, dis, jid, name);
            List<UserShowModel> pagelist = list.Skip((index - 1) * size).Take(size).ToList();
            GetPage<UserShowModel> page = new GetPage<UserShowModel>
            {
                Model = pagelist,
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
        [HttpGet]
        public JobTableModel ShowSingleJob(int id)
        {
            return _bll.ShowJob(id);
        }
        [HttpPost]
        public int AddSingleUser(string obj)
        {
            UserTableModel m = JsonConvert.DeserializeObject<UserTableModel>(obj);
            var s = m.User_Photo;
            if (Request.Form.Files.Count > 0)
            {
                //获取物理路径 webtootpath
                string path = _hostEnvironment.ContentRootPath + "\\wwwroot\\img";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var file = Request.Form.Files[0];
                string fileExt = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                string filename = Guid.NewGuid().ToString() + "." + fileExt;
                string fileFullName = path + "\\" + filename;
                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                m.User_Photo = "/img/" + filename;
            }
            return _bll.AddSingleUser(m);
        }
        [HttpPost]
        public int UpdateSingleUser(string obj)
        {
            UserTableModel m = JsonConvert.DeserializeObject<UserTableModel>(obj);
            var s = m.User_Photo;
            if (Request.Form.Files.Count > 0)
            {
                //获取物理路径 webtootpath
                string path = _hostEnvironment.ContentRootPath + "\\wwwroot\\img";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var file = Request.Form.Files[0];
                string fileExt = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                string filename = Guid.NewGuid().ToString() + "." + fileExt;
                string fileFullName = path + "\\" + filename;
                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                m.User_Photo = "/img/" + filename;
            }
            return _bll.UpdateSingleUser(m);
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
        [HttpGet]
        public int DelJob(string id)
        {
            string[] pid = id.Split(',');
            int i = 0;
            foreach (string cid in pid)
            {
                i = _bll.DelJob(int.Parse(cid));
            }
            if (i > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
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
        public int UpdateJobState(int id)
        {
            return _bll.UpdateJobState(id);
        }
        [HttpPost]
        public int AddJob(JobTableModel m)
        {
            return _bll.AddJob(m);
        }
        [HttpPut]
        public int PutJob(JobTableModel m)
        {
            return _bll.PutJob(m);
        }
        [HttpGet]
        public List<ListPermission> ShowPermission()
        {
            return _bll.ShowPermission();

        }
        [HttpGet]
        public List<PermissionRelationTableModel> ShowSinglePermission(int id)
        {
            return _bll.ShowSinglePermission(id);
        }
        [HttpGet]
        public List<PermissionRelationTableModel> ChkPid(int id)
        {
            return _bll.ChkPid(id);
        }
        [HttpGet]
        public UserShowModel SelectUserPhone(string phone)
        {
            return _bll.SelectUserPhone(phone);       
        }
        [HttpGet]
        public int PutPwd(string phone,string oldpwd,string newPwd)
        {
            return _bll.PutPwd(phone,oldpwd, newPwd);
        }
        [HttpGet]
        public BoothView GetLog(string time,string table)
        {
            return _bll.GetLog(time,table);
        }
        [HttpGet]
        public List<PieModel> GetCon(string time)
        {

            return _bll.GetCon(time);
        }
        [HttpGet]
        public int ChangePermission(int id,string ids)
        {
            return _bll.ChangePermission(id, ids);
        }
    }
}
