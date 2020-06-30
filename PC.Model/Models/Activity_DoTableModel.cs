using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
    /// <summary>
    /// 活动执行表
    /// </summary>
    public class Activity_DoTableModel
	 {
        //活动执行的主键
        public int  Id { get; set; }
        //外键（添加活动表）活动名称
        public int  Activity_Do_Activity_Id { get; set; }
        //医院
        public string  Activity_Do_Hospital { get; set; }
        //外键关联用户表
        public int  Activity_Do_User_Id { get; set; }
        //创建时间
        public DateTime  Activity_Do_CreateTime { get; set; }
        //结束时间
        public DateTime  Activity_Do_EndTime { get; set; }
        //活动状态
        public bool  Activity_Do_State { get; set; }
        //短信内容
        public string  Activity_Message_Desc { get; set; }
        //外键（会议表）会议编码
        public int  Activity_Do_Con_Id { get; set; }
        //外键，连接关系表的参会人Id(而且关系表中受邀人的审批状态为1才是参会)
        public int  Activity_Do_Inviter_User_Id { get; set; }
        //会议总结
        public string  Activity_Do_Final { get; set; }
        //会议照片
        public string  Activity_Do_Picture { get; set; }
	 }
}
