using PC.Common.Helpers;
using PC.IDAL.UserIDAL;
using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PC.DAL.UserDAL
{
    public class UDAL : IUDAL
    {
        DapperHelper<UserTableModel> dapper = new DapperHelper<UserTableModel>();
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Forget(UserTableModel m)
        {
            string sql = $"update UserTable set User_Pwd='{m.User_Pwd}' where User_Phone='{m.User_Phone}'";
            return dapper.Execute(sql);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user_Phone"></param>
        /// <param name="user_Pwd"></param>
        /// <returns></returns>
        public int Login(string user_Phone, string user_Pwd)
        {
            string sql = $"select * from UserTable where User_Phone={user_Phone} and User_Pwd = {user_Pwd} and User_State = 0 and User_DelState = 0 ";
            return dapper.Query(sql).ToList().Count();
        }
        /// <summary>
        /// 显示登录人名称
        /// </summary>
        /// <param name="user_Phone"></param>
        /// <returns></returns>
        public string SelectName(string user_Phone)
        {
            string sql = $"select * from UserTable where User_Phone={user_Phone}";
            string name = dapper.Query(sql).FirstOrDefault().User_Name;
            return name;
        }
        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        public List<DepartmentTableModel> ShowDepartment()
        {
            DapperHelper<DepartmentTableModel> dep = new DapperHelper<DepartmentTableModel>();
            string sql = "select * from DepartmentTable";
            return dep.Query(sql);
        }
        /// <summary>
        /// 显示职务
        /// </summary>
        /// <returns></returns>
        public List<JobTableModel> ShowJob()
        {
            DapperHelper<JobTableModel> dep = new DapperHelper<JobTableModel>();
            string sql = "select * from JobTable where Job_DelState = 0";
            return dep.Query(sql);
        }
        /// <summary>
        /// 显示城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<PlaceTableModel> ShowProvince(int id)
        {
            DapperHelper<PlaceTableModel> pla = new DapperHelper<PlaceTableModel>();
            string sql = "select * from PlaceTable where Pid=" + id;
            return pla.Query(sql);
        }
        /// <summary>
        /// 显示用户
        /// </summary>
        /// <param name="product"></param>
        /// <param name="did"></param>
        /// <param name="pid"></param>
        /// <param name="cid"></param>
        /// <param name="dis"></param>
        /// <param name="jid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name)
        {
            DapperHelper<UserShowModel> helper = new DapperHelper<UserShowModel>();
            string sql = "select u.Id,u.User_Phone,u.User_Name,u.User_Id,u.User_AddTime,d.Department_Name,j.Job_Name,p.Product_Name from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id where User_State = 0 and User_DelState = 0";
            sql += "  ";
            if (did != 0)
            {
                sql += " and User_Department=" + did;
            }
            if (pid != 0)
            {
                sql += " and User_Province=" + pid;
            }
            if (cid != 0)
            {
                sql += " and User_City=" + cid;
            }
            if (dis != 0)
            {
                sql += " and User_District=" + dis;
            }
            if (jid != 0)
            {
                sql += " and User_Job=" + jid;
            }
            if (!string.IsNullOrEmpty(name))
            {
                int flag = IsNumber(name);
                switch (flag)
                {
                    case 1:
                        sql += " and User_Phone=" + name;
                        break;
                    case 2:
                        sql += " and User_Name like '%" + name + "%'";
                        break;
                    case 3:
                        sql += " and User_Id like '%" + name + "%'";
                        break;
                }
            }
            if (product != 0)
            {
                sql += " and User_ProductId = " + product;
            }
            return helper.Query(sql);
        }
        /// <summary>
        /// 是否全是数字
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IsNumber(string name)
        {
            bool sz = Regex.IsMatch(name, @"^[+-]?\d*[.]?\d*$");
            if (sz)
            {
                return 1;
            }
            else
            {
                bool bflag = false;
                char[] c = name.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] >= 0x4E00 && c[i] <= 0x29FA5)
                    {
                        bflag = true;
                        return 2;// 有一个中文字符就返回
                    }
                }
                return 3;
            }
        }
        /// <summary>
        /// 编辑/显示个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserShowModel> SelectUser(int id)
        {
            DapperHelper<UserShowModel> helper = new DapperHelper<UserShowModel>();
            string sql = "select * from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id where User_State = 0 and User_DelState = 0 and u.Id =" + id;
            return helper.Query(sql);
        }
        /// <summary>
        /// 添加单个用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddSingleUser(UserTableModel m)
        {
            string sql = $"insert into UserTable values('" + m.User_Id + "','" + m.User_Name + "','" + m.User_Pwd + "'," + m.User_Sex + ",'" + m.User_Phone + "','" + m.User_Email + "','" + m.User_Wechat + "','" + m.User_QQ + "'," + m.User_Department + "," + m.User_Job + "," + m.User_Province + "," + m.User_City + "," + m.User_District + ",'" + m.User_Area + "','" + m.User_Address + "'," + m.User_ProductId + ",'" + m.User_Photo + "','" + DateTime.Now + "',0,'" + m.User_Desc + "',0)";
            return dapper.Execute(sql);
        }
        /// <summary>
        /// 删除单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelSingleUser(int id)
        {
            string sql = " update UserTable set User_DelState=1 where Id =" + id;
            return dapper.Execute(sql);
        }
        /// <summary>
        /// datatable 显示用户
        /// </summary>
        /// <returns></returns>
        public DataTable ShowUser()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345"))
            {
                string sql = "select u.Id,u.User_Phone,u.User_Name,u.User_Id,u.User_AddTime,d.Department_Name,j.Job_Name,p.Product_Name from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id";
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    SqlDataAdapter sqlData = new SqlDataAdapter();
                    sqlData.SelectCommand = com;
                    sqlData.Fill(tb);
                }
            }
            return tb;
        }
        /// <summary>
        /// 显示一些用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<UserShowModel> ShowSome(string ids)
        {
            DapperHelper<UserShowModel> helper = new DapperHelper<UserShowModel>();
            string sql = "select u.Id,u.User_Name,d.Department_Name,j.Job_Name,p.Product_Name from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id " + ids;
            return helper.Query(sql);
        }
        /// <summary>
        /// 弹出层  修改
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="sid"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public int UpdateSome(string gid, int sid, string action)
        {
            string sql = " update UserTable set ";
            switch (action)
            {
                case "job":
                    sql += " User_Job= " + sid;
                    break;
                case "department":
                    sql += " User_Department= " + sid;
                    break;
                case "Dead":
                    sql += " User_State= " + sid;
                    break;
                case "Freeze":
                    sql += " User_State= " + sid;
                    break;
                default:
                    break;
            }
            string[] pid = gid.Split(',');
            string ids = " where ";
            foreach (string cid in pid)
            {
                ids += " Id =" + int.Parse(cid) + " or";
            }
            ids = ids.Substring(0, (ids.Length - 2));
            sql = sql + ids;
            return dapper.Execute(sql);
        }

        public int UpdateSingleUser(UserTableModel m)
        {
            string sql = "update UserTable set User_Id='" + m.User_Id + "',User_Name='" + m.User_Name + "',User_Pwd='" + m.User_Pwd + "',User_Sex=" + m.User_Sex + ",User_Phone='" + m.User_Phone + "',User_Email='" + m.User_Email + "',User_Wechat='" + m.User_Wechat + "',User_QQ='" + m.User_QQ + "',User_Department=" + m.User_Department + ",User_Job=" + m.User_Job + ",User_Province=" + m.User_Province + ",User_City=" + m.User_City + ",User_District=" + m.User_District + ",User_Area='" + m.User_Area + "',User_Address='" + m.User_Address + "',User_ProductId=" + m.User_ProductId + ",User_Photo='" + m.User_Photo + "'";
            return dapper.Execute(sql);
        }
        public int UpdateJobState(int id)
        {
            DapperHelper<JobTableModel> job = new DapperHelper<JobTableModel>();
            string sql = "select * from JobTable where Id=" + id;
            JobTableModel m = job.Query(sql).FirstOrDefault();
            if (m.Job_State == 0)
            {
                sql = "update JobTable set Job_State=1 where id=" + id;
            }
            else if (m.Job_State == 1)
            {
                sql = "update JobTable set Job_State=0 where id=" + id;
            }
            else
            {
                return 0;
            }
            return job.Execute(sql);
        }

        public int DelJob(int v)
        {
            string sql = " update JobTable set Job_DelState=1 where Id =" + v;
            return dapper.Execute(sql);
        }
        public int PutJob(JobTableModel m)
        {
            string sql = " update JobTable set Job_Name = '" + m.Job_Name + "', Job_Desc='" + m.Job_Desc + "' where Id=" + m.Id;
            return dapper.Execute(sql);
        }
        public JobTableModel ShowJob(int id)
        {
            DapperHelper<JobTableModel> job = new DapperHelper<JobTableModel>();
            string sql = "select * from JobTable where Id=" + id;
            JobTableModel m = job.Query(sql).FirstOrDefault();
            return m;
        }
        public List<ListPermission> ShowPermission()
        {
            DapperHelper<PermissionTableModel> per = new DapperHelper<PermissionTableModel>();
            string sql = "select * from PermissionTable where Permission_Pid=0";
            List<PermissionTableModel> m = per.Query(sql);
            ListPermission lp = new ListPermission();

            List<ListPermission> list = new List<ListPermission>();
            foreach (PermissionTableModel model in m)
            {
                ListPermission pr =new ListPermission
                {
                    Id = model.Id,
                    Permission_Name = model.Permission_Name,
                    Permission_Pid = model.Permission_Pid,
                    ModelList = per.Query("select * from PermissionTable where Permission_Pid=" + model.Id)
                };
                list.Add(pr);
            }
            return list;
        }
        public List<PermissionRelationTableModel> ShowSinglePermission(int id)
        {
            DapperHelper<PermissionRelationTableModel> pr = new DapperHelper<PermissionRelationTableModel>();
            string sql = "select * from PermissionRelationTable pr where pr.Permission_Id =" + id;
            List<PermissionRelationTableModel> m = pr.Query(sql);
            return m;
        }
        public List<PermissionRelationTableModel> ChkPid(int id)
        {
            DapperHelper<PermissionRelationTableModel> pr = new DapperHelper<PermissionRelationTableModel>();
            string sql = "select * from PermissionTable p where p.Permission_Pid = " + id;
            List<PermissionRelationTableModel> m = pr.Query(sql);
            return m;
        }
        public UserShowModel SelectUserPhone(string phone)
        {
            DapperHelper<UserShowModel> helper = new DapperHelper<UserShowModel>();
            string sql = "select * from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id where User_State = 0 and User_DelState = 0 and User_Phone =" + phone;
            return helper.Query(sql).FirstOrDefault();
        }
        public int PutPwd(string phone, string oldpwd, string newPwd)
        {
            string sql = "select * from UserTable where User_Phone='"+ phone + "' and User_Pwd='"+oldpwd+"'";
            UserTableModel m = dapper.Query(sql).FirstOrDefault();
            if (m!=null)
            {
                sql = "update UserTable set User_Pwd='"+newPwd+ "' where User_Phone='"+ phone + "'";
                return dapper.Execute(sql); 
            }
            return 0;
        }
        public int AddJob(JobTableModel m)
        {
            string sql = " insert into JobTable values ('" + m.Job_Name + "','" + m.Job_Desc + "',1,'"+DateTime.Now +"',0,0)";
            return dapper.Execute(sql);
        }
    }
}