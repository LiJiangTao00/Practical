using PC.IDAL.Conference;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using PC.Common;
using System.Data.SqlClient;
using PC.Common.Helpers;

namespace PC.DAL.Conference
{
    public class ConferenceDal : IConferenceDal
    {
        public List<ConferenceShow> ShowConference()
        {
            DapperHelper<ConferenceShow> ShowConferenceDapper = new DapperHelper<ConferenceShow>();
            return ShowConferenceDapper.Query("select * from ConferenceTable join ConferenceTypeTable ct on Con_TypeId=ct.Id join ProductTable p on p.Id=Con_ProductId");
        }
    }
}
