using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ApprovalMaterial
    {
        public int Id { get; set; }
        //物料编号
        public string Material_Id { get; set; }
        //物料名称
        public string Material_Name { get; set; }
        //缩略图
        public string Material_Image { get; set; }
        //物料类型
        public string MType_Name { get; set; }
        //申请人
        public string Order_Proposer { get; set; }
        //区域
        public string Place_Name { get; set; }
        //提交时间
        public DateTime Order_SubmissionTime { get; set; }
        //审批时间
        public DateTime Order_ApproveTime { get; set; }
        //审批状态
        public int Material_Approval { get; set; }
        //活动名称
        public string Activity_Name { get; set; }
        //物料价格
        public float Material_Price { get; set; }
        //物料数量
        public int Material_Number { get; set; }
        //所属产品组
        public string Product_Name { get; set; }
        //部门
        public string Department_Name { get; set; }
        //职位
        public string Job_Name { get; set; }
        //联系方式
        public string User_Phone { get; set; }
        //申请时间
        public DateTime Order_ApplyTime { get; set; }
    }
}
