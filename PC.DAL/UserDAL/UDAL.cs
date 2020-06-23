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
            string sql = $"select * from UserTable where User_Phone={user_Phone} and User_Pwd = {user_Pwd}";
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
            return dapper.Query(sql).ToList()[0].User_Name;
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
            string sql = "select * from JobTable";
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
            string sql = "select u.Id,u.User_Phone,u.User_Name,u.User_Id,u.User_AddTime,d.Department_Name,j.Job_Name,p.Product_Name from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id";
            sql += " where 1=1 ";
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
            string sql = "select * from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id where u.Id =" + id;
            return helper.Query(sql);
        }
        /// <summary>
        /// 添加单个用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddSingleUser(UserTableModel m)
        {
            string sql = $"insert into UserTable values('" + m.User_Id + "','" + m.User_Name + "','" + m.User_Pwd + "'," + m.User_Sex + ",'" + m.User_Phone + "','" + m.User_Email + "','" + m.User_Wechat + "','" + m.User_QQ + "'," + m.User_Department + "," + m.User_Job + "," + m.User_Province + "," + m.User_City + "," + m.User_District + ",'" + m.User_Area + "','" + m.User_Address + "'," + m.User_ProductId + ",'" + m.User_Photo + "','" + m.User_AddTime + "'," + m.User_State + ",'" + m.User_Desc + "'," + m.User_DelState + ")";
            return dapper.Execute(sql);
        }
        public int DelSingleUser(int id)
        {
            string sql = " delete from UserTable where Id =" + id;
            return dapper.Execute(sql);
        }
        public DataTable ShowUser()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345"))
            {
                string sql = "select u.Id,u.User_Phone,u.User_Name,u.User_Id,u.User_AddTime,d.Department_Name,j.Job_Name,p.Product_Name from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id";
                con.Open();
                using (SqlCommand com = new SqlCommand(sql,con))
                {
                    SqlDataAdapter sqlData = new SqlDataAdapter();
                    sqlData.SelectCommand = com;
                    sqlData.Fill(tb);
                }
            }
            return tb;
        }
        /// <summary>
        /// 显示一些
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<UserShowModel> ShowSome(string ids)
        {
            DapperHelper<UserShowModel> helper = new DapperHelper<UserShowModel>();
            string sql = "select u.Id,u.User_Name,d.Department_Name,j.Job_Name,p.Product_Name from UserTable u join DepartmentTable d on u.User_Department = d.Id join JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id " + ids;
            return helper.Query(sql);
        }
    }
}