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

namespace PC.DAL.Conference
{
    public class ConferenceDal : IConferenceDal
    {
        

        //会议显示
        public List<ConferenceShow> ShowConference()
        {
            DapperHelper<ConferenceShow> ShowConferenceDapper = new DapperHelper<ConferenceShow>();
            return ShowConferenceDapper.Query("select * from ConferenceTable join ConferenceTypeTable ct on Con_TypeId=ct.Id join ProductTable p on p.Id=Con_ProductId");
        }
        //添加会议
        public int AddConference(ConferenceTableModel c)
        {
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
        public SearchPageShowConference SearchConference(DateTime condate, string conplace, string constate, string conname, int conproduct=-1, int pageindex=1, int pagesize=2)
        {
            DapperHelper<ConferenceShow> SearchConferenceDapper = new DapperHelper<ConferenceShow>();

            string sql = "select * from(select ROW_NUMBER() over(order by ConferenceTable.ID) orderid,ConferenceTable.ID,Con_Name,Con_Place,Con_StartTime,Con_EndTime,Con_State,Con_ProductId,Product_Name from ConferenceTable join ConferenceTypeTable ct on Con_TypeId=ct.Id join ProductTable p on p.Id=Con_ProductId where 1=1";
            
            if (condate!=null)
            {
                sql += "and Con_StartTime<condate and Con_EndTime>condate";
            }
            if (conplace!="")
            {
                sql += "and Con_Place like '%" + conplace + "%'";
            }
            if (constate== "进行中")
            {
                sql += "'and Con_StartTime'<'" + DateTime.Now + "'" + "'and Con_EndTime'>'" + DateTime.Now + "'";
            }
            if (constate == "已结束")
            {
                sql += "'and Con_EndTime'>'" + DateTime.Now + "'";
            }
            if (constate == "未开始")
            {
                sql += "'and Con_StartTime'<'" + DateTime.Now + "'";
            }
            if (conname!="")
            {
                sql += "and Con_Name like '%" + conname + "%'";
            }
            if (conproduct != -1)
            {
                sql += "and Con_ProductId=" + conproduct;
            }
            sql += "and where orderid between" + (pageindex - 1) * pagesize + 1 + " and  " + pageindex * pagesize;
            List<ConferenceShow> list = new List<ConferenceShow>();
            list = SearchConferenceDapper.Query(sql);
            SearchPageShowConference PageShowData = new SearchPageShowConference();
            PageShowData.PageShowConferenceList = list;
            PageShowData.DataCount = list.Count;
            PageShowData.PageSize = pagesize;
            return PageShowData;
        }


    }
}
