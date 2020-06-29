using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PC.Model.Models
{
	 public class ConferenceTableModel
	 {
		public int  Id { get; set; }
		public string  Con_ConId { get; set; }


		[Required(ErrorMessage ="必填项")]
		[StringLength(30)]
		public string  Con_Name { get; set; }
		[Required(ErrorMessage = "必填项")]
		public int  Con_TypeId { get; set; }
		[Required(ErrorMessage = "必填项")]
		[RegularExpression(@"^\d{4}-\d{1,2}-\d{1,2}", ErrorMessage = "请输入正确的时间格式")]
		public DateTime  Con_StartTime { get; set; }



		[Required(ErrorMessage = "必填项")]
		[RegularExpression(@"^\d{4}-\d{1,2}-\d{1,2}", ErrorMessage = "请输入正确的时间格式")]
		public DateTime  Con_EndTime { get; set; }



		[Required(ErrorMessage = "必填项")]
		public string  Con_Place { get; set; }
		[Required(ErrorMessage = "必填项")]
		public string  Con_OrganizationalUnit { get; set; }
		[Required(ErrorMessage = "必填项")]
		public int  Con_ProductId { get; set; }



		[Required(ErrorMessage = "必填项")]
		[RegularExpression(@"^\d{4}-\d{1,2}-\d{1,2}",ErrorMessage ="请输入正确的时间格式")]
		public DateTime  Con_QuotaEndTime { get; set; }



		[Required(ErrorMessage = "必填项")]
		[Range(10, 400, ErrorMessage="请输入10-400之间得数字")]
		public int  Con_QuotaNumber { get; set; }





		public string Con_SupportUnit { get; set; }
		public int  Con_ConDataId { get; set; }
		public string  Con_Desc { get; set; }
		public int  Con_State { get; set; }
		public string  Con_Admin { get; set; }
		public int  Con_DelState { get; set; }
	 }
}
