using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class SearchPageShowConference
    {
        //数据
        public List<ConferenceShow> PageShowConferenceList { get; set; }
        //数据总条数
        public int DataCount { get; set; }
        //页含量
        public int PageSize { get; set; }
        //总页数

        public int PageCount
        {
            get
            {
                if (DataCount % PageSize == 0)
                {
                    return DataCount / PageSize;
                }
                return (DataCount / PageSize) + 1;
            }
        }
    }
}
