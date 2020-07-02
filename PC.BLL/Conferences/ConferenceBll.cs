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
        public int AddConference(ConferenceAdd c)
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
        public SearchPageShowConference SearchConference(DateTime condate, string conplace, string constate, string conname, string conproduct, int pageindex = 1, int pagesize = 2)
        {
           
            return _dal.SearchConference(condate, conplace, constate, conname, conproduct, pageindex, pagesize);
        }

        //删除会议
        public int DelConference(string ids)
        {
            return _dal.DelConference(ids);
        }

        
        //会议详情（根据ID反填）
        public ConferenceInfo ConferenceInfo(int cid)
        {
            return _dal.ConferenceInfo(cid);
        }

        //会议统计 即根据条件查询会议数量

        public ConNums ConStatistics(string conproduct, int conyear = -1, int departmentid = -1, int con_typeid = -1)
        {
            
            return _dal.ConStatistics(conproduct,conyear ,departmentid, con_typeid);

        }
        //会议统计页面的部门下拉菜单
        public List<DepartmentTableModel> DepSel()
        {

            return _dal.DepSel();
        }

        //会议统计页面的会议类型下拉菜单
        public List<ConferenceTypeTableModel> ConTypeSel()
        {

            return _dal.ConTypeSel();
        }
        //修改名额时按会议id显示的小组长列表+此列表的条件查询
        public List<ParticipantTable> ShowParticipantsByConid(int conid, string DaQv = "", string DiQv = "", string PhoneOrName = "")
        {

            return _dal.ShowParticipantsByConid(conid, DaQv, DiQv, PhoneOrName);
        }
        //修改小组长可带参会名额  即修改名单关系表中：参会人可带人员数量
        public int UptQuotaNumByUid(int uid, int conid, int num)
        {

            return _dal.UptQuotaNumByUid(uid, conid, num);

        }

        //分配名额显示所有与该会议id无关的小组长
        public List<ParticipantTable> ShowUsersNoConid(int conid, string DaQv, string DiQv, string PhoneOrName)
        {

            return _dal.ShowUsersNoConid(conid, DaQv, DiQv, PhoneOrName);
        }
        //分配名额 即贼关系表中添加数据
        public int AddQuota(int uid, int conid, int num)
        {

            return _dal.AddQuota(uid, conid, num);
        }


    }
}
