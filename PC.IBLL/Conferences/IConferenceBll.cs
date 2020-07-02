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
        List<ConferenceShow> ShowConference();
        //添加会议
        int AddConference(ConferenceAdd c);
        //查询会议
        SearchPageShowConference SearchConference(DateTime condate, string conplace, string constate, string conname, string conproduct, int pageindex, int pagesize);
        //删除会议
        int DelConference(string ids);
        //会议详情（根据ID反填）
        ConferenceInfo ConferenceInfo(int cid);
        //会议统计 即根据条件查询会议数量
        ConNums ConStatistics(string conproduct, int conyear, int departmentid, int con_typeid);
        //会议统计页面的部门下拉菜单
       List<DepartmentTableModel>  DepSel();

        //会议统计页面的会议类型下拉类型下拉菜单
        List<ConferenceTypeTableModel> ConTypeSel();
        //修改名额时按会议id显示的小组长列表+此列表的条件查询+分页
        List<ParticipantTable> ShowParticipantsByConid(int conid, string DaQv, string DiQv, string PhoneOrName);
        //修改小组长可带参会名额  即修改名单关系表中：参会人可带人员数量
        int UptQuotaNumByUid(int uid, int conid, int num);

        //分配名额显示所有与该会议id无关的小组长
        List<ParticipantTable> ShowUsersNoConid(int conid, string DaQv, string DiQv, string PhoneOrName);
        //分配名额 即贼关系表中添加数据
        int AddQuota(int uid, int conid, int num);
    }
}
