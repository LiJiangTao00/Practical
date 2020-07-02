using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ConferenceAdd
    {
		public int Id { get; set; }
		public string Con_ConId { get; set; }
		public string Con_Name { get; set; }
		public int Con_TypeId { get; set; }
		public DateTime Con_StartTime { get; set; }
		public DateTime Con_EndTime { get; set; }
		public string Con_Place { get; set; }
		public string Con_OrganizationalUnit { get; set; }
		public int Con_ProductId { get; set; }
		public DateTime Con_QuotaEndTime { get; set; }
		public int Con_QuotaNumber { get; set; }
		public string Con_SupportUnit { get; set; }
		public int Con_ConDataId { get; set; }
		public string Con_Desc { get; set; }
		public int Con_State { get; set; }
		public string Con_Admin { get; set; }
		public int Con_DelState { get; set; }
	}
}
