using PC.IDAL.Conference;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using PC.Common;
using System.Data.SqlClient;
using PC.Common.Helpers;
using PC.Model.Models;
using NPOI.SS.Formula.Functions;
using System.Linq;
using Dapper;

namespace PC.DAL.Conference
{
    public class ConferenceDal : IConferenceDal
    {


        //会议显示
        public List<ConferenceShow> ShowConference()
        {
            DapperHelper<ConferenceShow> ShowConferenceDapper = new DapperHelper<ConferenceShow>();
            return ShowConferenceDapper.Query("select * from ConferenceTable join ConferenceTypeTable ct on Con_TypeId=ct.Id join ProductTable p on p.Id=Con_ProductId where Con_DelState=1");
        }
        //添加会议
        public int AddConference(ConferenceTableModel c)
        {
            c.Con_ConId = "GC" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            c.Con_DelState = 1;
            c.Con_ConDataId = 1;//没做 默认是1
            DapperHelper<ConferenceTableModel> ConferenceDapper = new DapperHelper<ConferenceTableModel>();
            return ConferenceDapper.Execute($"insert into ConferenceTable values('{c.Con_Name}','{c.Con_ConId}','{c.Con_TypeId}','{c.Con_StartTime}','{c.Con_EndTime}','{c.Con_Place}','{c.Con_OrganizationalUnit}','{c.Con_SupportUnit}','{c.Con_ProductId}','{c.Con_QuotaEndTime}','{c.Con_QuotaNumber}','{c.Con_ConDataId}','{c.Con_Desc}','{c.Con_State}','{c.Con_Admin}','1')");
        }
        /// <summary>
        /// 查询会议
        /// </summary>
        /// <param name="condate">要查询的时间点</param>
        /// <param name="conplace">要查询的会议地址</param>
        /// <param name="constate">要查询的会议状态</param>
        /// <param name="conname">要查询的会议名称关键字</param>
        /// <param name="conproduct">要查询的会议产品组</param>
        /// <returns></returns>
        public SearchPageShowConference SearchConference(DateTime condate, string conplace, string constate, string conname, string conproduct, int pageindex = 1, int pagesize = 2)
        {
            DapperHelper<ConferenceShow> SearchConferenceDapper = new DapperHelper<ConferenceShow>();

            string sql = "select * from(select ROW_NUMBER() over(order by ConferenceTable.ID) orderid,ConferenceTable.ID,Con_Name,Con_Place,Con_StartTime,Con_EndTime,Con_State,Con_ProductId,Product_Name,Con_DelState from ConferenceTable join ConferenceTypeTable ct on Con_TypeId=ct.Id join ProductTable p on p.Id=Con_ProductId) tempview where 1=1";

            if (condate != DateTime.Parse("0001/1/1 0:00:00"))
            {
                sql += "and Con_StartTime<'" + condate + "' and Con_EndTime> '" + condate + " '";
            }
            if (conplace != null)
            {
                sql += " and Con_Place like '%" + conplace + "%'";
            }
            if (constate == "进行中")
            {
                sql += " and Con_StartTime <'" + DateTime.Now + "'" + " and Con_EndTime >'" + DateTime.Now + "'";
            }
            if (constate == "已结束")
            {
                sql += " and Con_EndTime <'" + DateTime.Now + "'";
            }
            if (constate == "未开始")
            {
                sql += " and Con_StartTime >'" + DateTime.Now + "'";
            }
            if (conname != null)
            {
                sql += " and Con_Name like '%" + conname + "%'";
            }
            if (conproduct != "default_proc")
            {
                sql += " and Product_Name like '%" + conproduct + "%'";
            }
            sql += " and Con_DelState=1"; //Con_DelState为假删状态 1：存在  0：已被删除
            List<ConferenceShow> list = new List<ConferenceShow>();
            list = SearchConferenceDapper.Query(sql);

            var pagelist = list.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();

            SearchPageShowConference SearchData = new SearchPageShowConference();
            SearchData.PageShowConferenceList = pagelist;
            SearchData.DataCount = list.Count();
            SearchData.PageSize = pagesize;

            return SearchData;
        }
        //删除会议
        public int DelConference(string ids)
        {
            DapperHelper<ConferenceTableModel> ConferenceDapper = new DapperHelper<ConferenceTableModel>();
            string sql = "update ConferenceTable set Con_DelState=0 where id in (" + ids + ") ";
            return ConferenceDapper.Execute(sql);
        }
        //会议详情（根据ID反填）
        public ConferenceInfo ConferenceInfo(int cid)
        {
            DapperHelper<ConferenceShow> ShowConferenceDapper = new DapperHelper<ConferenceShow>();
            ConferenceInfo info = new ConferenceInfo();
            //会议详情
            info.con = ShowConferenceDapper.Query($"select * from ConferenceTable join ConferenceTypeTable ct on Con_TypeId=ct.Id join ProductTable p on p.Id=Con_ProductId where ConferenceTable.ID={cid}").First();
            //记录会议id 通过会议id找到参会医生行id 通过行id 找到参会医生邀请并且通过审批的人员数量
            using (SqlConnection conn = new SqlConnection(@"Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345"))
            {
                info.concomenum = Convert.ToInt32(conn.ExecuteScalar($"select count(1) from InvitationTable where Inviter_User_Id in (select id from  QuotaTable where QRelation_ConferenceId = {info.con.Id}) and Invitation_State = 1"));
            }

            return info;
        }

        //会议统计 即根据条件查询会议数量

        public ConNums ConStatistics(string conproduct= "default_proc", int conyear=-1, int departmentid=-1, int con_typeid=-1)
        {
            DapperHelper<ConferenceBar> ConferenceBarDapper = new DapperHelper<ConferenceBar>();

            string sql = "select * from ConferenceTable " +
                "join ConferenceTypeTable  on Con_TypeId=ConferenceTable.Id " +
                "join ProductTable  on ProductTable.Id=Con_ProductId " +
                "join UserTable on UserTable.id=ConferenceTable.Con_Admin " +
                "join  DepartmentTable on   UserTable.User_Department=DepartmentTable.id where 1=1";
            if (conproduct != "default_proc")
            {
                sql += " and Product_Name like '%" + conproduct + "%'";
            }
            
            if (con_typeid != -1)
            {
                sql += " and Con_TypeId =" + con_typeid;
            }


            if (departmentid != -1)
            {
                sql += " and DepartmentTable.Id ="+ departmentid;
            }           

            sql += " and Con_DelState=1"; //Con_DelState为假删状态 1：存在  0：已被删除
            List<ConferenceBar> list = new List<ConferenceBar>();
            list = ConferenceBarDapper.Query(sql);
            if (conyear != -1)//如果选择了年份 则查找该年份的会议
            {
                list = list.Where(line => line.Con_StartTime.Year == conyear).ToList();
            }
            else//否则默认当前年份
            {
                list = list.Where(line => line.Con_StartTime.Year == DateTime.Now.Year).ToList();
            }
            ConNums conNums = new ConNums();
            conNums.JanNums = list.Where(line => line.Con_StartTime.Month == 1).Count();
            conNums.FebNums = list.Where(line => line.Con_StartTime.Month == 2).Count();
            conNums.MarNums =list.Where(line => line.Con_StartTime.Month == 3).Count();
            conNums.AprNums = list.Where(line => line.Con_StartTime.Month == 4).Count();
            conNums.MayNums = list.Where(line => line.Con_StartTime.Month == 5).Count();
            conNums.JunNums = list.Where(line => line.Con_StartTime.Month == 6).Count();
            conNums.JulNums = list.Where(line => line.Con_StartTime.Month == 7).Count();
            conNums.AugNums = list.Where(line => line.Con_StartTime.Month == 8).Count();
            conNums.SepNums = list.Where(line => line.Con_StartTime.Month == 9).Count();
            conNums.OctNums = list.Where(line => line.Con_StartTime.Month == 10).Count();
            conNums.NovNums = list.Where(line => line.Con_StartTime.Month == 11).Count();
            conNums.DecNums = list.Where(line => line.Con_StartTime.Month == 12).Count();

            return conNums;

        }


        //会议统计页面的部门下拉菜单
        public List<DepartmentTableModel> DepSel()
        {
            DapperHelper<DepartmentTableModel> DepartmentTableDapper = new DapperHelper<DepartmentTableModel>();
            string sql = "Select * from DepartmentTable";
            return DepartmentTableDapper.Query(sql);
        }

        //会议统计页面的会议类型下拉菜单
        public List<ConferenceTypeTableModel> ConTypeSel()
        {
            DapperHelper<ConferenceTypeTableModel> ConferenceTypeTableDapper = new DapperHelper<ConferenceTypeTableModel>();
            string sql = "Select * from ConferenceTypeTable";
            return ConferenceTypeTableDapper.Query(sql);
        }

    }
}
