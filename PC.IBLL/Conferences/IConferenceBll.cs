using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.IBLL.Conferences
{
    public interface IConferenceBll
    {
        //会议显示
        public List<ConferenceShow> ShowConference();
        //添加会议
        public int AddConference(ConferenceTableModel c);

    }
}
