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
        SearchPageShowConference SearchConference(DateTime condate,string conplace,string constate,string conname,string conproduct,int pageindex,int pagesize);
        //删除会议
        int DelConference(string ids);
        //会议详情（根据ID反填）
        ConferenceInfo ConferenceInfo(int cid);
        //会议统计 即根据条件查询会议数量
        ConNums ConStatistics(string conproduct, int conyear, int departmentid, int con_typeid);
        //会议统计页面的部门下拉菜单
        List<DepartmentTableModel> DepSel();

        //会议统计页面的会议类型下拉菜单
        List<ConferenceTypeTableModel> ConTypeSel();

    }
}
