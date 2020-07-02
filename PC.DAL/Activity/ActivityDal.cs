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
using PC.Model.ViewModel;

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
            return dep.Query(sql).FirstOrDefault().Department_Name == null ? "" : dep.Query(sql).FirstOrDefault().Department_Name;
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
        /// <summary>
        /// 查看执行情况
        /// </summary>
        /// <returns></returns>
        public List<Activity_DoTableModel> Execute(int id)
        {
            DapperHelper<Activity_DoTableModel> dep = new DapperHelper<Activity_DoTableModel>();
            string sql = $"select * from Activity_DoTable where Activity_Do_Activity_Id={id}";
            return dep.Query(sql);
        }
        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActivityTableModel GetActivity(int id)
        {
            DapperHelper<ActivityTableModel> dapper = new DapperHelper<ActivityTableModel>();
            string sql = $"select * from ActivityTable where id=" + id;
            return dapper.Query(sql).FirstOrDefault();
        }
        /// <summary>
        /// 统计报表
        /// </summary>
        /// <returns></returns>
        public List<ActivityShowView> ShowView()
        {
            DapperHelper<ActivityShowView> dapper = new DapperHelper<ActivityShowView>();
            string sql = "select Product_Name,count(1) Pcount from ActivityTable join ProductTable on Activity_Product_Id=ProductTable.Id group by Product_Name";
            return dapper.Query(sql).ToList();
        }
        /// <summary>
        /// 显示执行的列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ActivityZLY> zLies(int id, int did, int pid, int cid, int dis, string name)
        {
            List<ActivityZLY> list = (from d in ShowActivity_DoTable()
                                      join a in ShowActivityTable()
                                      on d.Activity_Do_Activity_Id equals a.Id
                                      join u in ShowUserTable()
                                      on d.Activity_Do_User_Id equals u.Id
                                      join c in ShowConferenceTable()
                                      on d.Activity_Do_Con_Id equals c.Id
                                      join i in ShowInvitationTable()
                                      on d.Activity_Do_Inviter_User_Id equals i.Id
                                      join j in ShowJobTable()
                                      on u.User_Job equals j.Id
                                      select new ActivityZLY
                                      {
                                          Id = a.Id,
                                          Activity_Do_Activity_Id = d.Activity_Do_Activity_Id,
                                          Con_ConId = c.Con_ConId,
                                          Activity_Name = a.Activity_Name,
                                          Con_QuotaNumber = c.Con_QuotaNumber,
                                          Activity_Do_Hospital = d.Activity_Do_Hospital,
                                          User_Name = u.User_Name,
                                          User_Area = u.User_Area,
                                          Job_Name = j.Job_Name,
                                          TimeBegin = c.Con_StartTime,
                                          TimeEnd = c.Con_EndTime,
                                          ActivityState_Id = a.ActivityState_Id,
                                          User_Department = u.User_Department,
                                          User_Job = u.User_Job,
                                          User_Province = u.User_ProductId,
                                          User_City = u.User_City,
                                          User_District = u.User_District,

                                      }).ToList();
            list = list.Where(x => x.Activity_Do_Activity_Id == id).ToList();
            //string sql = "select c.Con_ConId,a.Activity_Name,d.Activity_Do_Hospital,u.User_Name,u.User_Area,j.Job_Name,d.Activity_Do_CreateTime,d.Activity_Do_EndTime,d.Activity_Do_State 
            //              from Activity_DoTable d join ActivityTable a
            //              on d.Activity_Do_Activity_Id = a.Id join UserTable u
            //              on d.Activity_Do_User_Id = u.Id join ConferenceTable c
            //              on d.Activity_Do_Con_Id = c.Id join InvitationTable i
            //              on d.Activity_Do_Inviter_User_Id = i.Id join JobTable j
            //              on u.User_Job = j.Id";
            return list;
        }
        public List<Activity_DoTableModel> ShowActivity_DoTable()
        {
            DapperHelper<Activity_DoTableModel> dapper = new DapperHelper<Activity_DoTableModel>();
            string sql = "select * from Activity_DoTable";
            return dapper.Query(sql).ToList();
        }
        public List<ActivityTableModel> ShowActivityTable()
        {
            DapperHelper<ActivityTableModel> dapper = new DapperHelper<ActivityTableModel>();
            string sql = "select * from ActivityTable";
            return dapper.Query(sql).ToList();
        }
        public List<UserTableModel> ShowUserTable()
        {
            DapperHelper<UserTableModel> dapper = new DapperHelper<UserTableModel>();
            string sql = "select * from UserTable";
            return dapper.Query(sql).ToList();
        }

        public List<ConferenceTableModel> ShowConferenceTable()
        {
            DapperHelper<ConferenceTableModel> dapper = new DapperHelper<ConferenceTableModel>();
            string sql = "select * from ConferenceTable";
            return dapper.Query(sql).ToList();
        }
        public List<InvitationTableModel> ShowInvitationTable()
        {
            DapperHelper<InvitationTableModel> dapper = new DapperHelper<InvitationTableModel>();
            string sql = "select * from InvitationTable";
            return dapper.Query(sql).ToList();
        }

        public List<JobTableModel> ShowJobTable()
        {
            DapperHelper<JobTableModel> dapper = new DapperHelper<JobTableModel>();
            string sql = "select * from JobTable";
            return dapper.Query(sql).ToList();
        }
        /// <summary>
        /// 显示物料订单信息
        /// </summary>
        /// <returns></returns>
        //public List<ShowMaterialApprove> GetShowMaterialApprove()
        //{
        //    List<ShowMaterialApprove> list = (from m in ShowMaterial()
        //                                      join o in GetOrder()
        //                                      on m.Id equals o.Order_MId
        //                                      join t in GetTypes()
        //                                      on m.Material_TypeId equals t.Id
        //                                      join a in ShowActivity()
        //                                      on m.Material_Activity_Id equals a.Id
        //                                      join u in GetUsers()
        //                                      on o.Order_User_Id equals u.Id
        //                                      join p in GetProduct()
        //                                      on o.Order_Product_Id equals p.Id
        //                                      join d in GetDepartment()
        //                                      on o.Order_Department_Id equals d.Id
        //                                      join j in GetJob()
        //                                      on o.Order_Job_Id equals j.Id
        //                                      join g in GetPlace()
        //                                      on o.Order_Area_Id equals g.Id
        //                                      select new ShowMaterialApprove
        //                                      {
        //                                         Material_Id = m.Material_Id,
        //                                         Material_Name = m.Material_Name,
        //                                         Material_Image = m.Material_Image,
        //                                         MType_Name = t.MType_Name,
        //                                         Order_Proposer = o.Order_Proposer,
        //                                         Place_Name = g.Place_Name,
        //                                         Order_ApplyTime = o.Order_ApplyTime,
        //                                         Order_State = o.Order_State,
        //                                         Activity_Name = a.Activity_Name,
        //                                         Material_Price = m.Material_Price,
        //                                         Material_Number = m.Material_Number,
        //                                          Product_Name = p.Product_Name,
        //                                          Department_Name = d.Department_Name,
        //                                          Job_Name = j.Job_Name,
        //                                          User_Phone = u.User_Phone
        //                                      }).ToList();
        //    return list;
        //}
    }
}
