using PC.IBLL.Activity;
using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.BLL.Activity
{
    class ActivityBll : IActivityBll
    {
        private readonly IActivityBll bll;

        public ActivityBll(IActivityBll bll)
        {
            this.bll = bll;
        }

        public int AddActivity(ActivityTableModel activity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        public List<Activity_DoTableModel> ShowActivity()
        {
            return bll.ShowActivity();
        }

        public List<ActivityStateTableModel> ShowActivityState()
        {
            throw new NotImplementedException();
        }

        public List<ActivityTypeTableModel> ShowActivityType()
        {
            throw new NotImplementedException();
        }
    }
}
