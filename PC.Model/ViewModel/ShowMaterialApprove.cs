using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ShowMaterialApprove
    {
        public int Material_Id { get; set; }
        public int Material_Name { get; set; }
        public int Material_Image { get; set; }
        public int MType_Name { get; set; }
        public int Order_Proposer { get; set; }
        public int Order_ApplyTime { get; set; }
        public int Order_ApproveTime { get; set; }
        public int Material_Approval { get; set; }
    }
}
