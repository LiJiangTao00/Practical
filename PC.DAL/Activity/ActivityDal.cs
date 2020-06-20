using PC.IDAL.Activity;
using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace PC.DAL.Activity
{
    public class ActivityDal : IActivityDal
    {
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
            using (SqlConnection connection = new SqlConnection("Data Source = 192.168.43.93; Initial Catalog = Practial; User ID = sa; Pwd = 12345"))
            {
                return connection.Query<Activity_DoTableModel>("select * from Activity_DoTableModel").ToList();
            }
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
