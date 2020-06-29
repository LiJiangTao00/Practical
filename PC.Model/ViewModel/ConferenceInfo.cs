using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ConferenceInfo
    {
        //会议详情况
        public ConferenceShow con{ get; set; }
        //已确定参加会议人数
        public int  concomenum{ get; set; }
        //会议剩余名额
        public int consurplusnum { get {
                return con.Con_QuotaNumber - concomenum;          
            
            } }
    }
}
