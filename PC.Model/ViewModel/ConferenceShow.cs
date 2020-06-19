using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ConferenceShow
{

	public int Id { get; set; }
	public string Con_ConId { get; set; }
	public string Con_Name { get; set; }
	public int Con_TypeId { get; set; }
	public DateTime Con_StartTime { get; set; }
	public DateTime Con_EndTime { get; set; }
	public string Con_Place { get; set; }
	public string Con_OrganizationalUnit { get; set; }
	public string Con_SupportUnit { get; set; }
	public int Con_ProductId { get; set; }
	public DateTime Con_QuotaEndTime { get; set; }
	public int Con_QuotaNumber { get; set; }
	public int Con_ConDataId { get; set; }
	public string Con_Desc { get; set; }
	public int Con_State { get; set; }
	public string Con_Admin { get; set; }
	public int Con_DelState { get; set; }



	public string ConType_Name { get; set; }
	public string VonType_Desc { get; set; }


	public string Product_Name { get; set; }
	public string Product_Desc { get; set; }
}
