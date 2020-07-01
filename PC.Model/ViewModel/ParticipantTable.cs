using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    //参会人表
    public class ParticipantTable
    {
        public int uid { get; set; }
        public string User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Pwd { get; set; }
        public int User_Sex { get; set; }
        public string User_Phone { get; set; }
        public string User_Email { get; set; }
        public string User_Wechat { get; set; }
        public string User_QQ { get; set; }
        public int User_Department { get; set; }
        public int User_Job { get; set; }
        public int User_Province { get; set; }
        public int User_City { get; set; }
        public int User_District { get; set; }
        public string User_Area { get; set; }
        public string User_Address { get; set; }
        public int User_ProductId { get; set; }
        public string User_Photo { get; set; }
        public DateTime User_AddTime { get; set; }
        public int User_State { get; set; }
        public string User_Desc { get; set; }
        public int User_DelState { get; set; }
        public string Department_Name { get; set; }
        public string Product_Name { get; set; }
        public string Job_Name { get; set; }


        public int QRelation_Userid { get; set; }
        public int QRelation_ConferenceId { get; set; }
        public int QRelation_Number { get; set; }
        public string QRelation_Desc { get; set; }




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






    }
}
