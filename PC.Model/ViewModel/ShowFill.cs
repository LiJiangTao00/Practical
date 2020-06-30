using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ShowFill
    {
		public int Id { get; set; }
		public string Material_Id { get; set; }
		public string Material_Name { get; set; }
		public int Material_TypeId { get; set; }
		public float Material_Price { get; set; }
		public int Material_Number { get; set; }
		public int Material_LastNumber { get; set; }
		public string Material_Desc { get; set; }
		public string Material_Image { get; set; }
		public int Material_State { get; set; }
		public int Material_Approval { get; set; }
		public int Material_Recycle { get; set; }
		public DateTime Material_AddTime { get; set; }
		public int Material_DelState { get; set; }
		public string MType_Name { get; set; }
	}
}
