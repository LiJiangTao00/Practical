using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.IBLL.Activity
{
    public interface IActivityBll
    {
        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        List<Activity_DoTableModel> ShowActivity();
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        int AddActivity(ActivityTableModel activity);
        /// <summary>
        /// 显示活动状态
        /// </summary>
        /// <returns></returns>
        List<ActivityStateTableModel> ShowActivityState();
        /// <summary>
        /// 显示活动类型
        /// </summary>
        /// <returns></returns>
        List<ActivityTypeTableModel> ShowActivityType();
    }
}
