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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="User_Phone"></param>
        /// <param name="User_Pwd"></param>
        /// <returns></returns>
        [HttpGet]
        public int Login(string User_Phone, string User_Pwd)
        {
            return _bll.Login(User_Phone, User_Pwd);
        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPut]
        public int Forget(UserTableModel m)
        {
            return _bll.Forget(m);
        }
        /// <summary>
        /// 获取登录人名称
        /// </summary>
        /// <param name="User_Phone"></param>
        /// <returns></returns>
        [HttpGet]
        public string SelectName(string User_Phone)
        {
            return _bll.SelectName(User_Phone);
        }
        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DepartmentTableModel> ShowDepartment()
        {
            return _bll.ShowDepartment();
        }
        /// <summary>
        /// 显示省
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<PlaceTableModel> ShowProvince(int pid = 0)
        {
            return _bll.ShowProvince(pid);
        }
        /// <summary>
        /// 显示分页
        /// </summary>
        /// <param name="product"></param>
        /// <param name="did"></param>
        /// <param name="pid"></param>
        /// <param name="cid"></param>
        /// <param name="dis"></param>
        /// <param name="jid"></param>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        public GetPage<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name, int index = 1, int size = 3)
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
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public UserShowModel SelectUser(int id)
        {
            return _bll.SelectUser(id).FirstOrDefault();
        }
        /// <summary>
        /// 显示职位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<JobTableModel> ShowJob()
        {
            return _bll.ShowJob();
        }
        /// <summary>
        /// 获取单个职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JobTableModel ShowSingleJob(int id)
        {
            return _bll.ShowJob(id);
        }
        /// <summary>
        /// 添加单个用户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 导出信息
        /// </summary>
        /// <param name="path"></param>
        [HttpPost]
        public void PutOut([FromBody] string path)
        {
            DataTable tb = _bll.ShowUser();
            OledbExcelHelper.DataTableToExcel(path, tb);
        }
        /// <summary>
        /// 显示一些用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 修改多个用户
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="sid"></param>
        /// <param name="desc"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpGet]
        public int UpdateSome(string gid, int sid, string desc, string action)
        {
            return _bll.UpdateSome(gid, sid, action);
        }
        /// <summary>
        /// 修改职位状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateJobState(int id)
        {
            return _bll.UpdateJobState(id);
        }
        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddJob(JobTableModel m)
        {
            return _bll.AddJob(m);
        }
        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPut]
        public int PutJob(JobTableModel m)
        {
            return _bll.PutJob(m);
        }
        /// <summary>
        /// 显示权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ListPermission> ShowPermission()
        {
            return _bll.ShowPermission();

        }
        /// <summary>
        /// 显示某个职位的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<PermissionRelationTableModel> ShowSinglePermission(int id)
        {
            return _bll.ShowSinglePermission(id);
        }
        /// <summary>
        /// 权限关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<PermissionRelationTableModel> ChkPid(int id)
        {
            return _bll.ChkPid(id);
        }
        /// <summary>
        /// 根据手机查询用户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        public UserShowModel SelectUserPhone(string phone)
        {
            return _bll.SelectUserPhone(phone);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="oldpwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [HttpGet]
        public int PutPwd(string phone, string oldpwd, string newPwd)
        {
            return _bll.PutPwd(phone, oldpwd, newPwd);
        }
        /// <summary>
        /// 获取首页中添加条数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpGet]
        public BoothView GetLog(string time, string table)
        {
            return _bll.GetLog(time, table);
        }
        /// <summary>
        /// 饼图
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpGet]
        public List<PieModel> GetCon(string time)
        {

            return _bll.GetCon(time);
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public int ChangePermission(int id, string ids)
        {
            return _bll.ChangePermission(id, ids);
        }
    }
}
