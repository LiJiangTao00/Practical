using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ActivityZLY
    {
        public int Id { get; set; }
        //外键（会议表）会议编码
        public string Con_ConId { get; set; }
        public int Activity_Do_Activity_Id { get; set; }

        //活动名称
        public string Activity_Name { get; set; }
        //医院
        public string Activity_Do_Hospital { get; set; }

        //举办人
        public string User_Name { get; set; }

        //区域
        public string User_Area { get; set; }
        //职位
        public string Job_Name { get; set; }

        //开始
        public DateTime? TimeBegin { get; set; }

        //结束
        public DateTime? TimeEnd { get; set; }

        //状态
        public int ActivityState_Id { get; set; }

        //参会人数
        public int Con_QuotaNumber { get; set; }

        //实际人数
        public int Number { get; set; }

        //照片
        public int Picture { get; set; }
        public int User_Department { get; set; }
        public int User_Job { get; set; }
        public int User_Province { get; set; }
        public int User_City { get; set; }
        public int User_District { get; set; }
    }
}
