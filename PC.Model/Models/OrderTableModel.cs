using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class OrderTableModel
	 {
		 public int  Id { get; set; }
		 public int  Order_MId { get; set; }
		 public int  Order_MTypeId { get; set; }
		 public string  Order_Proposer { get; set; }
		 public DateTime  Order_ApplyTime { get; set; }
		 public DateTime Order_SubmissionTime { get; set; }
		 public DateTime Order_ApproveTime { get; set; }
        public int  Order_State { get; set; }
		 public string  Order_Number { get; set; }
		 public string  Order_Consignee { get; set; }
		 public string  Order_ConsigneePhone { get; set; }
		 public string  Order_ConsigneeSite { get; set; }
		 public string  Order_Remark { get; set; }
		 public string  Order_Staff { get; set; }
		 public int  Order_Product_Id { get; set; }
		 public int  Order_Department_Id { get; set; }
		 public int  Order_Job_Id { get; set; }
		 public int  Order_Area_Id { get; set; }
		 public int  Order_User_Id { get; set; }
	 }
}
