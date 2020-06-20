using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;
using PC.Model.ViewModel;
namespace PC.IDAL.Conference
{
    public interface IConferenceDal
    {
        //会议显示
        List<ConferenceShow> ShowConference();
        //添加会议
        int AddConference(ConferenceTableModel c);
        //查询会议
        List<ConferenceShow> SearchConference(DateTime condate,string conplace,string constate,string conname,int conproduct);
    }
}
