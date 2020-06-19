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
        public List<ConferenceShow> ShowConference();
        //添加会议
        public int AddConference(ConferenceTableModel c);
    }
}
