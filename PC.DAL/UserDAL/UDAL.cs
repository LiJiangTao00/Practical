using PC.Common.Helpers;
using PC.IDAL.UserIDAL;
using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PC.DAL.UserDAL
{
    public class UDAL : IUDAL
    {
        DapperHelper<UserTableModel> dapper = new DapperHelper<UserTableModel>();
        public int Forget(UserTableModel m)
        {
            string sql = $"update UserTable set User_Pwd='{m.User_Pwd}' where User_Phone='{m.User_Phone}'";
            return dapper.Execute(sql);
        }

        public int Login(string user_Phone, string user_Pwd)
        {
            string sql = $"select * from UserTable where User_Phone={user_Phone} and User_Pwd = {user_Pwd}";
            return dapper.Query(sql).ToList().Count();
        }

        public string SelectName(string user_Phone)
        {
            string sql = $"select * from UserTable where User_Phone={user_Phone}";
            return dapper.Query(sql).ToList()[0].User_Name;
        }

        public List<DepartmentTableModel> ShowDepartment()
        {
            DapperHelper<DepartmentTableModel> dep = new DapperHelper<DepartmentTableModel>();
            string sql = "select * from DepartmentTable";
            return dep.Query(sql);
        }
        public List<UserShowModel> ShowUser()
        {
            DapperHelper<UserShowModel> helper = new DapperHelper<UserShowModel>();
            string sql = "select u.Id,u.User_Phone,u.User_Name,u.User_Id,u.User_AddTime,d.Department_Name,j.Job_Name,p.Product_Namefrom UserTable u join DepartmentTable d on u.User_Department = d.Idjoin JobTable j on u.User_Job = j.Id join ProductTable p on u.User_ProductId = p.Id";
            return helper.Query(sql);
        }
    }
}
