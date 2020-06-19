using PC.DAL.Conference;
using PC.IBLL.Conferences;
using PC.IDAL.Conference;
using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.BLL.Conferences
{
    public class ConferenceBll : IConferenceBll
    {
        public IConferenceDal _dal;
        public ConferenceBll(IConferenceDal dal)
        {
            _dal = dal;
        }
        //会议显示
        public List<ConferenceShow> ShowConference()
        {
            return _dal.ShowConference();
        }
        //添加会议
        public int AddConference(ConferenceTableModel c)
        {

            return _dal.AddConference(c);
        }


    }
}
