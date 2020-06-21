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
        /// <summary>
        /// 查询会议
        /// </summary>
        /// <param name="condate">要查询的时间点</param>
        /// <param name="conplace">要查询的会议地址</param>
        /// <param name="constate">要查询的会议状态</param>
        /// <param name="conname">要查询的会议名称关键字</param>
        /// <param name="conproduct">要查询的会议产品组</param>
        /// <returns></returns>
        public SearchPageShowConference SearchConference(DateTime condate, string conplace, string constate, string conname, int conproduct, int pageindex = 1, int pagesize = 2)
        {
           
            return _dal.SearchConference(condate, conplace, constate, conname, conproduct, pageindex, pagesize);
        }

    }
}
