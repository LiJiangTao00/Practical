using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PC.IBLL.Activity
{
    public interface IActivityBll
    {
        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        List<ActivityTableModel> ShowActivity();

        /// 显示活动类型下拉框
        /// </summary>
        /// <returns></returns>
        List<ActivityTypeTableModel> ShowType();

        /// <summary>
        /// 显示活动状态下拉框
        /// </summary>
        /// <returns></returns>
        List<ActivityStateTableModel> ShowState();

        /// <summary>
        /// 显示部门下拉框
        /// </summary>
        /// <returns></returns>
        List<DepartmentTableModel> ShowDep();

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        int AddActivity(ActivityTableModel model);

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelActivity(int id);

        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdActivity(ActivityTableModel model);
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetDepartName(int id);
        /// <summary>
        /// 获取活动类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetActivityName(int id);

        /// <summary>
        /// 显示详情
        /// </summary>
        /// <returns></returns>
        List<ActivityTableModel> Details(int id);

        /// <summary>
        /// 查看执行情况
        /// </summary>
        /// <returns></returns>
        List<Activity_DoTableModel> Execute(int id);

        /// <summary>
        /// 获取活动
        /// </summary>
        /// <returns></returns>
        ActivityTableModel GetActivity(int id);
        /// <summary>
        /// 显示统计
        /// </summary>
        /// <returns></returns>
        List<ActivityShowView> ShowView();
        /// <summary>
        /// 显示执行页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ActivityZLY> zLies();
    }
}
