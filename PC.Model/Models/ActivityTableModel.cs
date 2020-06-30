using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
    /// <summary>
    /// 添加活动表
    /// </summary>
    public class ActivityTableModel
	 {
        //添加活动表主键
        public int  Id { get; set; }
        //外键（活动类型表）
        public int  ActivityType_Id { get; set; }
        //活动名称
        public string  Activity_Name { get; set; }
        //活动描述
        public string  Activity_Desc { get; set; }
        //上传资料
        public string  Activity_Data { get; set; }
        //外键（产品组表）
        public int  Activity_Product_Id { get; set; }
        //外键（部门表）
        public int  Acticity_Department_Id { get; set; }
        //假删
        public int  Activity_DelState { get; set; }
        ///状态
        public int ActivityState_Id { get; set; }
        //开始
        public DateTime? TimeBegin { get; set; }
        //结束
        public DateTime? TimeEnd { get; set; }
    }
}
