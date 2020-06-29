using PC.IDAL.Activity;
using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PC.Common.Helpers;
using NPOI.SS.Formula.Functions;

namespace PC.DAL.Activity
{
    public class ActivityDal : IActivityDal
    {
        DapperHelper<ActivityTableModel> helper = new DapperHelper<ActivityTableModel>();
        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        public List<ActivityTableModel> ShowActivity()
        {
            DapperHelper<ActivityTableModel> dapper = new DapperHelper<ActivityTableModel>();
            string sql = "select * from ActivityTable where Activity_DelState=0";
            List<ActivityTableModel> list = dapper.Query(sql);
            return list;
        }
        /// <summary>
        /// 显示活动类型下拉框
        /// </summary>
        /// <returns></returns>
        public List<ActivityTypeTableModel> ShowType()
        {
            DapperHelper<ActivityTypeTableModel> dapper = new DapperHelper<ActivityTypeTableModel>();
            string sql = "select * from ActivityTypeTable";
            List<ActivityTypeTableModel> list = dapper.Query(sql);
            return list;
        }
        /// <summary>
        /// 显示活动状态下拉框
        /// </summary>
        /// <returns></returns>
        public List<ActivityStateTableModel> ShowState()
        {
            DapperHelper<ActivityStateTableModel> dapper = new DapperHelper<ActivityStateTableModel>();
            string sql = "select * from ActivityStateTable";
            List<ActivityStateTableModel> list = dapper.Query(sql);
            return list;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int AddActivity(ActivityTableModel model)
        {
            string sql = ($"insert into ActivityTable values ({model.ActivityType_Id},'{model.Activity_Name}','{model.Activity_Desc}','{model.Activity_Data}','{model.Activity_Product_Id}',{model.Acticity_Department_Id},'0','{model.ActivityState_Id}','{model.TimeBegin}','{model.TimeEnd}')");
            return helper.Execute(sql);
        }
        /// <summary>
        /// 显示部门下拉框
        /// </summary>
        /// <returns></returns>
        public List<DepartmentTableModel> ShowDep()
        {
            DapperHelper<DepartmentTableModel> dep = new DapperHelper<DepartmentTableModel>();
            string sql = "select * from DepartmentTable";
            return dep.Query(sql);
        }
        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelActivity(int id)
        {
            string sql = "update ActivityTable set Activity_DelState=1 where Id=" + id;
            return helper.Execute(sql);
        }
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdActivity(ActivityTableModel model)
        {
            string sql = " update ActivityTable set ActivityType_Id = '" + +model.ActivityType_Id + "', Activity_Name='" + model.Activity_Name + "',Activity_Desc='" + model.Activity_Desc + "',Activity_Data='" + model.Activity_Data + "',Activity_Product_Id='" + model.Activity_Product_Id + "',Acticity_Department_Id='" + model.Acticity_Department_Id + "',ActivityState_Id='" + model.ActivityState_Id + "',TimeBegin='" + model.TimeBegin + "',TimeEnd='" + model.TimeEnd + "' where Id=" + model.Id;
            return helper.Execute(sql);
        }
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDepartName(int id)
        {
            DapperHelper<DepartmentTableModel> dep = new DapperHelper<DepartmentTableModel>();
            string sql = $"select * from DepartmentTable where id={id} ";
            return dep.Query(sql).FirstOrDefault().Department_Name==null?"": dep.Query(sql).FirstOrDefault().Department_Name;
        }
        /// <summary>
        /// 获取活动类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetActivityName(int id)
        {
            DapperHelper<ActivityTypeTableModel> dapper = new DapperHelper<ActivityTypeTableModel>();
            string sql = $"select * from ActivityTypeTable where id={id}";
            ActivityTypeTableModel list = dapper.Query(sql).FirstOrDefault();
            return list.ActivityType_Name;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ActivityTableModel> Details(int id)
        {
            DapperHelper<ActivityTableModel> dep = new DapperHelper<ActivityTableModel>();
            string sql = $"select Activity_Desc from ActivityTable where Id={id}";
            return dep.Query(sql);
        }

        public List<Activity_DoTableModel> Execute()
        {
            DapperHelper<Activity_DoTableModel> dep = new DapperHelper<Activity_DoTableModel>();
            string sql = $"select * from Activity_DoTable";
            return dep.Query(sql);
        }
    }
}
