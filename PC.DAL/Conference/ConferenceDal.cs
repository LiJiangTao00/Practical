using PC.IDAL.Conference;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using PC.Common;
using System.Data.SqlClient;
using PC.Common.Helpers;
using PC.Model.Models;

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



    }
}
