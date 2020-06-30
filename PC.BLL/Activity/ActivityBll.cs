using PC.IBLL.Activity;
using PC.IDAL.Activity;
using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PC.BLL.Activity
{
    public class ActivityBll : IActivityBll
    {
        private readonly IActivityDal dal;

        public ActivityBll(IActivityDal dal)
        {
            this.dal = dal;
        }     
        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        public List<ActivityTableModel> ShowActivity()
        {
            return dal.ShowActivity();
        }
        /// <summary>
        /// 显示活动类型下拉框
        /// </summary>
        /// <returns></returns>
        public List<ActivityTypeTableModel> ShowType()
        {
            return  dal.ShowType();
        }
        /// <summary>
        /// 显示活动状态下拉框
        /// </summary>
        /// <returns></returns>
        public List<ActivityStateTableModel> ShowState()
        {
            return  dal.ShowState();
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddActivity(ActivityTableModel model)
        {
            return  dal.AddActivity(model);
        }
        /// <summary>
        /// 显示部门下拉
        /// </summary>
        /// <returns></returns>
        public List<DepartmentTableModel> ShowDep()
        {
            return dal.ShowDep();
        }

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelActivity(int id)
        {
            return dal.DelActivity(id);
        }
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdActivity(ActivityTableModel model)
        {
            return dal.UpdActivity(model);
        }
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDepartName(int id)
        {
            return dal.GetDepartName(id);
        }
        /// <summary>
        /// 获取活动类别名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetActivityName(int id)
        {
            return dal.GetActivityName(id);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ActivityTableModel> Details(int id)
        {
            return dal.Details(id);
        }

        public List<Activity_DoTableModel> Execute()
        {
            return dal.Execute();
        }
        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActivityTableModel GetActivity(int id)
        {
            return dal.GetActivity(id);
        }
    }
}
